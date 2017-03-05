using Imitation.Elements;
using System.Collections.Generic;

namespace Imitation
{
	public class Model
	{
		private List<Element> _elementQueue;
		private List<Element> _elementAction;
		private int Time;

		public Model()
		{
			this._elementQueue = new List<Element>();
			this.Time = 0;
			this.InitModel();
		}

		public void InitModel()
		{
			Generator enter = new Enter(3, 3.0); // 3 transact each 3 seconds
			Exit exit = new Exit();

			enter.ReadyToGive += exit.Take;

			this._elementQueue.Enqueue(enter);
			this._elementQueue.Enqueue(exit);
		}

		public void Process()
		{
			while(this.Check())
			{
				foreach(var element in _elementAction)
				{
					element.Process();
				}
			}
		}

		private bool Check()
		{
			int min = this._elementQueue[0].Next;
			foreach(var element in _elementQueue)
			{
				if (element.Next < min)
				{
					this._elementAction.Clear();
					min = element.Next;
					this._elementAction.Add(element);
				} else if (element.Next == min) {
					this._elementAction.Add(element);
				}
			}

			return this._elementAction.Count > 0;
		}
	}
}
