namespace Imitation.Elements
{
	public class Service : Executor
	{
		private double _interval;

		public Service()
		{
			this._interval = 0;
		}

		public Service(double interval)
		{
			this._interval = interval;
		}

		public override void Execute()
		{
			this.Ready();
		}
	}
}
