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

		public override Transact Execute(Transact transact)
		{
			if (this.Try())
			{ 
				System.Console.WriteLine("Service ready");
				this.Ready = true;
				return this.Process(transact);
			}
			else 
			{
				return null;
			}
		}

		public override bool Try()
		{
			return this.Transacts.Count == 0;
		}

		public override Transact Process(Transact transact)
		{
			transact.Time = this._interval;
			return transact;
		}
	}
}
