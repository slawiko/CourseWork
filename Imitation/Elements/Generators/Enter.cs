namespace Imitation.Elements
{
	public sealed class Enter : Generator
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

		public Enter(int delay)
		{
			var random = new System.Random(2);
			this.Transact = new Transact(random);
			this.Delay = delay;
			this.Next = delay;
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
