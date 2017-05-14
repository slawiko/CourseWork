using System.Collections.Generic;
using ImitationLib.Elements.Core;
using ImitationLib.Utils;

namespace ImitationLib.Elements
{
	public sealed class Exit : Collector
	{
		public Exit(int delay, int capacity = Constants.InfiniteQueueCapacity)
		{
			this.Delay = delay;
			this._capacity = capacity;
			this.Transacts = new Queue<Transact>();
			this.ReadyIn = Constants.ReadyToTake;
		}
	}
}
