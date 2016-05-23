using Imitation.Elements;
using System.Collections.Generic;

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
