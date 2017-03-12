namespace Imitation.Elements
{
	public class Service : Executor
	{
		public override In In { get; set; }
		public override Out Out { get; set; }

		protected override Transact Transact { get; set; }

		private int _next;
		public override int Next
		{
			get
			{
				return this._next;
			}
			set
			{
				if (value != 0)
				{
					this._next = value;
				}
				else
				{
					this._next = this.Delay;
				}
			}
		}
		public override int Delay { get; protected set; }

		public Service(int delay)
		{
			this.Delay = delay;
			this.Next = -1;
		}

		public override void Enter(Transact transact)
		{
			this.Transact = transact;
			this.Next = this.Delay;
		}

		public override Transact Exit()
		{
			return this.Transact;
		}

		public override void Process(int time)
		{
			this.Transact.Time = time;
			this.Out(this.Exit());
		}
	}
}
