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
			this._interval = interval > 0 ? interval : 0;
		}

		public override void Execute()
		{
			System.Console.WriteLine("Service ready");
			this.Ready();
		}
	}
}
