﻿using Imitation.Elements;
using System.Collections.Generic;

namespace Imitation
{
	public class Model
	{
		private List<Element> _elementQueue;
		private List<Element> _elementAction;
		public int Time { get; private set; }

		public Model()
		{
			this._elementQueue = new List<Element>();
			this._elementAction = new List<Element>();
			this.Time = 0;
			this.InitModel();
			this.Run();
		}

		public void InitModel()
		{
			Generator enter = new Enter(5);
			Executor service = new Service(8);
			Collector exit = new Exit(0);

			enter.Out += service.Enter;
			service.In += enter.Exit;

			service.Out += exit.Enter;
			exit.In += service.Exit;

			this._elementQueue.Add(enter);
			this._elementQueue.Add(service);
			this._elementQueue.Add(exit);
		}	

		public void Run()
		{
			while(this.Check())
			{
				foreach(var element in _elementAction)
				{
					element.Process(this.Time);
				}
			}
		}

		private bool Check()
		{
			int min = this._elementQueue[0].Next;
			foreach(var element in _elementQueue)
			{
				if (element.Next < min && element.Next >= 0)
				{
					this._elementAction.Clear();
					min = element.Next;
					this._elementAction.Add(element);
				} else if (element.Next == min) {
					this._elementAction.Add(element);
				}
			}
			this.Increment(min);

			return this._elementAction.Count > 0;
		}

		private void Increment(int incr)
		{
			this.Time += incr;
			foreach(var element in _elementQueue)
			{
				element.Next -= incr;
			}
		}
	}
}
