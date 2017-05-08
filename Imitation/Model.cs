using Imitation.Elements;
using System.Collections.Generic;
using System.Linq;

public class Model
{
	private List<Element> ElementsList;
	private List<Element> ActionList;
	private List<Element> WaitingList;

	public int Time { get; private set; }

	public Model()
	{
		this.ElementsList = new List<Element>();
		this.ActionList = new List<Element>();
		this.WaitingList = new List<Element>();
		this.Time = 0;
		this.InitModel();
	}

	public void InitModel()
	{
		Generator enter = new Enter(5, 3);
		Executor service = new Service(8);
		Collector exit = new Exit(0);

		enter.Out += service.Enter;
		service.Out += exit.Enter;

		service.In += enter.Exit;
		exit.In += service.Exit;

		this.ElementsList.Add(enter);
		this.ElementsList.Add(service);
		this.ElementsList.Add(exit);
	}	

	public void Run()
	{
		int nextTick = this.NextTick();
		while(nextTick >= 0)
		{
			this.Increment(nextTick);
			nextTick = this.NextTick();
		}

		System.Console.WriteLine("Model finished");
	}

	private int NextTick()
	{
		this.ActionList.Clear();
		this.WaitingList.Clear();

		int min = this.FirstPositive();

		foreach(var element in this.ElementsList)
		{
			// TODO: refactor this
			if (element.Next < 0)
			{
				continue;
			}
			if (element.Next < min)
			{
				this.WaitingList.AddRange(this.ActionList);
				this.ActionList.Clear();
				min = element.Next;
				this.ActionList.Add(element);
			} 
			else if (element.Next == min)
			{
				this.ActionList.Add(element);
			} 
			else 
			{
				this.WaitingList.Add(element);
			}
		}

		return min;
	}

	private void Increment(int incr)
	{
		this.Time += incr;
		this.Wait(incr);
		this.Action(incr);
	}

	private void Wait(int incr)
	{	
		foreach(var element in this.WaitingList)
		{
			element.Next -= incr;
		}
	}

	private void Action(int incr)
	{
		foreach (var element in this.ActionList)
		{
			element.Process(this.Time);
		}
	}

	private int FirstPositive()
	{
		// TODO: refactor it
		var temp = this.ElementsList.Where(element => element.Next >= 0).ToList();
		if (temp.Count > 0)
		{
			return temp[0].Next;
		}
		return -1;
	}
}
