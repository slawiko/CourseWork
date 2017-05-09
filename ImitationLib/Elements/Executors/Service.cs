using ImitationLib.Elements.Core;

namespace ImitationLib.Elements
{
	public sealed class Service : Executor
	{
		public Service(int delay)
		{
			this.Delay = delay;
			this.ReadyIn = -1;
		}
	}
}
