using System.Collections.Generic;

namespace Imitation.Elements
{
	public class Queue : Accumulator
	{
		private Queue<Transact> _queue;
		private int _capacity;

		public Queue()
		{
			this._queue = new Queue<Transact>();
			this._capacity = -1;
		}

		public Queue(int capacity)
		{
			this._queue = new Queue<Transact>();
			this._capacity = capacity > 0 ? capacity : -1;
		}

		public override void Enter()
		{
			this.Ready();
		}
	}
}
