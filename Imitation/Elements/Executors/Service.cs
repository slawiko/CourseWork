namespace Imitation.Elements
{
	public class Service : Executor
	{
		public Service(int delay)
		{
			this.Delay = delay;
			this.Next = -1;
		}
	}
}
