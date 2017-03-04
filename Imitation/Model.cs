using Imitation.Elements;
using System.Collections.Generic;

/// <summary>
/// 1)      Модель должна содержать список всех элементов (генераторы, задаржки, очереди и т.д.) и управлять модельным временем. И это не singleton потому что теоретически в будущем можно иметь несколько моделей.
/// 2)      Элементы модели содержат входы и выходы.С выхода снимается объект-транзакт и передается на вход следующего элемента.
/// 3)      Транзакты накапливают параметры и статистику прохождения.
/// 4)      Модель обходит все элементы проверяет их свойство Next.Он вернет время когда состояние элемента в очередной раз изменится.Это время может совпасть с начальным модельным – если в элементе нет задержки.
/// 5)      Если это время превышает время окончание моделирования – останавливаем расчёт.Вызываем метод отображения выдающий окончательный результат.
/// 6)      Модель выбирает один(или несколько, если одновременно готовы несколько) элементов с наименьшим заявленным временем смены состояния.
/// 7)      Для них вызывается метод Process, в который передается текущее модельное время.Его задача переместить необходимые транзакты со входа(входов) элемента(или создать новые – если генератор, или создать копии и т.д.) на вход следующего в цепочке.Результатом будет список элементов чьи входы изменились.Модель собирает их в общий список, удаляя дубликаты.
/// 8)      Когда все элементы отработали свой Process модель обходит список элементов с изменёнными входами и вызывает Process для них.Это будет продолжаться до тех пор, пока очередной результирующий список не станет пуст.
/// 9)      Теперь модель может вызвать некий метод отображения – перерисовываем графики отражающее состояние и т.д.
/// 10)     Когда нет больше кандидатов на вызов Process – переходим к п.4. Только здесь уже вряд ли какой-то из элементов имеет право вернуть текущее модельное время.
/// </summary>

namespace Imitation
{
	public class Model
	{
		private Queue<Element> _elementQueue;
		private Generator _entry;
		public Model()
		{
			this._elementQueue = new Queue<Element>();
			this.Init();
			this.Start();
		}
		 
		public void Init()
		{
			Generator enter = new Enter(3);
			Accumulator queue = new Queue(10); 
			Executor service = new Service();
			Exit exit = new Exit();

			this._entry = enter;
			enter.Next += queue.Enter;
			queue.Next += service.Execute;
			service.Next += exit.Collect;

			this._elementQueue.Enqueue(enter);
			this._elementQueue.Enqueue(queue);
			this._elementQueue.Enqueue(service);
			this._elementQueue.Enqueue(exit);
		}

		public void Start()
		{
			while (this.HasReady())
			{
				foreach (var item in this._elementQueue)
				{
					if (item.ReadyToGive) item.Continue();
				}
			}
		}

		private bool HasReady()
		{
			foreach (var item in this._elementQueue)
			{
				if (item.ReadyToGive) return true;
			}
			return false;
		}
	}
}
