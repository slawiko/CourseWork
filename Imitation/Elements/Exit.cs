namespace Imitation.Elements
{
	public class Exit : Collector
	{
		public override void Collect()
		{
			System.Console.WriteLine("Exit ready");
			this.Ready();
		}
	}
}
