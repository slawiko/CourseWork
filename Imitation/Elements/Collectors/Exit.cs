namespace Imitation.Elements
{
	public class Exit : Collector
	{
		public override Transact Collect(Transact transact)
		{
			System.Console.WriteLine("Exit ready");
			this.Ready = true;
			return transact; // ?
		}

		public override Transact Process(Transact transact)
		{
			System.Console.WriteLine(transact);
			return base.Process(transact);
		}
	}
}
