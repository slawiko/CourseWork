using System.Collections.Generic;
using ImitationLib.Elements.Core;
using ImitationLib.Utils;

namespace ImitationLib.Elements
{
	public sealed class Exit : Collector
	{
		public Exit(int delay)
		{
			this.CollectedTransacts = new List<Transact>();
			this.Delay = delay;
			this.ReadyIn = Constants.DefaultReadyIn;
		}
	}
}
