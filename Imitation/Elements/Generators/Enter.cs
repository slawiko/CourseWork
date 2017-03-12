namespace Imitation.Elements
{
	public sealed class Enter : Generator
	{
		private Transact _transact;
		private int _next;
		protected override Transact Transact 
		{ 
			get { return this._transact; }
			set { this._transact = value; } 
		}

		public override int Next
		{
			get { return this._next; }
			protected set { this._next = value; }
		}

		Enter(int delay)
		{
			this.Next = delay;
		}

		public override Transact Exit()
		{
			return this.Transact;
		}

		public override void Process(int time)
		{
			this.Transact.Time = time;
		}
	}
}
