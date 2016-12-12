using Imitation.Elements;
using System.Collections.Generic;

namespace Imitation
{
	public class Model
	{
		private Queue<Element> _elementQueue;

		public Model()
		{
			this._elementQueue = new Queue<Element>();
			this.Init();
			this.Start();
		}
		 
		public void Init()
		{
			Generator enter = new Enter(3, 3.0); // 3 transact each 3 seconds
			Exit exit = new Exit();

			enter.ReadyToGive += exit.Take;

			this._elementQueue.Enqueue(enter);
			this._elementQueue.Enqueue(exit);
		}

		public void Start()
		{
			var firstElement = this._elementQueue.Dequeue();

			firstElement.Process();
		}
	}
}
