using System.Collections.Generic;
using System.Linq;
using ImitationLib.Elements.Core;
using ImitationLib.Utils;


/// 1)      Модель должна содержать список всех элементов (генераторы, задаржки, очереди и т.д.) и управлять модельным временем. И это не singleton потому что теоретически в будущем можно иметь несколько моделей.
/// 2)      Элементы модели содержат входы и выходы.С выхода снимается объект-транзакт и передается на вход следующего элемента.
/// 3)      Транзакты накапливают параметры и статистику прохождения.
/// 4)      Модель обходит все элементы проверяет их свойство ReadyIn.Он вернет время когда состояние элемента в очередной раз изменится.Это время может совпасть с начальным модельным – если в элементе нет задержки.
/// 5)      Если это время превышает время окончание моделирования – останавливаем расчёт.Вызываем метод отображения выдающий окончательный результат.
/// 6)      Модель выбирает один(или несколько, если одновременно готовы несколько) элементов с наименьшим заявленным временем смены состояния.
/// 7)      Для них вызывается метод Process, в который передается текущее модельное время.Его задача переместить необходимые транзакты со входа(входов) элемента(или создать новые – если генератор, или создать копии и т.д.) на вход следующего в цепочке.Результатом будет список элементов чьи входы изменились.Модель собирает их в общий список, удаляя дубликаты.
/// 8)      Когда все элементы отработали свой Process модель обходит список элементов с изменёнными входами и вызывает Process для них.Это будет продолжаться до тех пор, пока очередной результирующий список не станет пуст.
/// 9)      Теперь модель может вызвать некий метод отображения – перерисовываем графики отражающее состояние и т.д.
/// 10)     Когда нет больше кандидатов на вызов Process – переходим к п.4. Только здесь уже вряд ли какой-то из элементов имеет право вернуть текущее модельное время.
///
/// <summary>
/// 1) Модель обходит все элементы и проверяет их свойство ReadyIn. ReadyIn содержит время спустя которое, состояние элемента в очередной раз изменится. Это время может быть нулем, если в элементе нет задержки.
/// 2) Модель выбирает один(или несколько, если одновременно готовы несколько) элементов с наименьшим заявленным временем смены состояния.
/// 3) Для них вызывается метод Process, в который передается текущее модельное время. Его задача переместить необходимые транзакты со входа(входов) элемента(или создать новые – если генератор, или создать копии и т.д.) на вход следующего в цепочке.
/// 4) Переходим к пункту 1
/// </summary>
public class Model
{
	/// <summary>
	/// List of all elements in model
	/// </summary>
	private readonly List<Element> _elementsList;

	/// <summary>
	/// List of elements that can be processed
	/// </summary>
	private readonly List<Element> _actionList;

	/// <summary>
	/// List of elements that are now waiting
	/// </summary>
	private readonly List<Element> _waitingList;

	/// <summary>
	/// Model time
	/// </summary>
	public int Time { get; private set; }

	public Model()
	{
		this._elementsList = new List<Element>();
		this._actionList = new List<Element>();
		this._waitingList = new List<Element>();

		this.Time = 0;
	}

	/// <summary>
	/// Runs main cycle of <see cref="Model"/>
	/// </summary>
	public void Run()
	{
		Logger.Log.Info("Model started");

		int nextTick = this.Tick();
		while (nextTick >= 0)
		{
			this.Increment(nextTick);
			nextTick = this.Tick();
		}

		Logger.Log.Info("Model finished\n");
	}

	// TODO: #15
	public void LinkElements(Generator enter, Collector exit, params Executor[] executors)
	{
		enter.Out += executors.First().Take;

		for (int i = 0; i < executors.Length - 1; i++)
		{
			executors[i].Out += executors[i + 1].Take;
		}

		executors.Last().Out += exit.Take;

		this._elementsList.Add(enter);
		this._elementsList.AddRange(executors);
		this._elementsList.Add(exit);
	}

	/// <summary>
	/// Finds minimal <see cref="Element.ReadyIn"/> and fills <see cref="_waitingList"/>
	/// and <see cref="_actionList"/> with items from <see cref="_elementsList"/>.
	/// </summary>
	/// <returns>minimal <see cref="Element.ReadyIn"/></returns>
	private int Tick()
	{
		this._actionList.Clear();
		this._waitingList.Clear();

		int min = this.MinReadyIn();

		this._actionList.AddRange(this._elementsList.Where(element => element.ReadyIn == min));
		this._waitingList.AddRange(this._elementsList.Where(element => element.ReadyIn > min));

		return min;
	}

	/// <summary>
	/// Increments <see cref="Time"/> and each <see cref="Element"/>'s state in <see cref="Model"/>
	/// </summary>
	/// <param name="incr"></param>
	private void Increment(int incr)
	{
		this.Time += incr;
		this.Wait(incr);
		this.Action();
	}

	/// <summary>
	/// Increments <see cref="Element.ReadyIn"/> for each <see cref="Element"/> from <see cref="_waitingList"/>
	/// </summary>
	/// <param name="incr"></param>
	private void Wait(int incr)
	{
		foreach (var element in this._waitingList)
		{
			element.ReadyIn -= incr;
		}
	}

	/// <summary>
	/// Does <see cref="Element.Process"/> on each <see cref="Element"/> from <see cref="_actionList"/>
	/// </summary>
	private void Action()
	{
		foreach (var element in this._actionList)
		{
			element.Process(this.Time);
		}
	}

	/// <summary>
	/// Calculates minimal <see cref="Element.ReadyIn"/> in <see cref="_elementsList"/>>
	/// </summary>
	/// <returns>Minimal <see cref="Element.ReadyIn"/> or <see cref="Constants.DefaultReadyIn"/> if no positive values</returns>
	private int MinReadyIn()
	{
		return this._elementsList
			.Select(element => element.ReadyIn)
			.OrderBy(readyIn => readyIn)
			.Where(readyIn => readyIn >= 0)
			.DefaultIfEmpty(Constants.DefaultReadyIn)
			.First();
	}
}