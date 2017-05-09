namespace ImitationLib.Elements
{
	public class Service : Executor
	{
		public Service(int delay)
		{
			this.Delay = delay;
			this.ReadyIn = -1;
		}
	}
}
