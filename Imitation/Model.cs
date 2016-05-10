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
			InitModel();
		}

		public void InitModel()
		{
			Generator enter = new Enter(1.0);
			Accumulator queue = new Queue();
			Executor service = new Service();
			Sink sink = new Sink();

			enter.Next += queue.Enter;
			queue.Next += service.Execute;
			service.Next += sink.Collect;
		}
	}
}
