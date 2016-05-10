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
		}

		public Queue(int capacity)
		{
			this._capacity = capacity > 0 ? capacity : -1;
			this._occupancy = 0;
		}

		public override void Enter()
		{
			if (this.Try())
			{
				System.Console.WriteLine("Queue ready");
				this.Ready();
			}
			else 
			{
				// TODO
			}
		}

		public override bool Try()
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

		public override bool IsFinite()
		{
			return this._capacity != -1 ? true : false;
		}
	}
}
