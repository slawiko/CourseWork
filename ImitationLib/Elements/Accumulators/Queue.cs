/*
namespace Imitation.Elements
{
	public class Queue : Accumulator
	{
		private int _capacity;
		private int _occupancy;

		public Queue()
		{
			this._capacity = -1;
			this._occupancy = 0;
			this.Transacts = new System.Collections.Generic.Queue<Transact>();
		}

		public Queue(int capacity)
		{
			this._capacity = capacity > 0 ? capacity : -1;
			this._occupancy = 0;
			this.Transacts = new System.Collections.Generic.Queue<Transact>();
		}

		private bool IsFinite()
		{
			return this._capacity != -1 ? true : false;
		}

		public override void Enter(Transact transact)
		{
			if (this.Try())
			{
				this.Transacts.Enqueue(transact);
				this.Update();
			}
			else
			{
				// TODO
			}
		}

		public bool Try()
		{
			if ((this._capacity > this._occupancy) || !this.IsFinite())
			{
				this._occupancy++;
				return true;
			}
			else
			{
				return false;
			}
		}
	}
}
*/
