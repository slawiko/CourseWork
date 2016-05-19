namespace Imitation.Elements
{
	public class Service : Executor
	{
		private double _interval;

		public Service()
		{
			this._interval = 0;
			this.Transacts = new System.Collections.Generic.Queue<Transact>();
		}

		public Service(double interval)
		{
			this._interval = interval > 0 ? interval : 0;
			this.Transacts = new System.Collections.Generic.Queue<Transact>();
		}

		public override void Execute(Transact transact)
		{
			if (this.Try())
			{
				this.Transacts.Enqueue(transact);
				this.Update();
			}
		}

		public bool Try()
		{
			return this.Transacts.Count == 0;
		}
	}
}
