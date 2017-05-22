using ImitationLib.Elements.Core;

namespace ImitationLib.Elements
{
	public sealed class Service : Executor
	{
		public Service(int delay, int capacity) : base(delay, capacity) {}
	}
}
