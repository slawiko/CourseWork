namespace Imitation.Elements
{
	public class Exit : Collector
	{
		public Exit()
		{
			this.ReadyToGive = true;
		}
		public override void Collect(Transact transact)
		{
			System.Console.WriteLine(transact);
		}
	}
}
