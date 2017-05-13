using System.Collections.Generic;
using ImitationLib.Elements.Core;
using ImitationLib.Utils;

namespace ImitationLib.Elements
{
	public sealed class Service : Executor
	{
		public Service(int delay, int capacity = Constants.InfiniteQueue)
		{
			this.Delay = delay;
			this._capacity = capacity;
			this.Transacts = new Queue<Transact>();
			this.ReadyIn = Constants.DefaultReadyIn;
		}
	}
}
