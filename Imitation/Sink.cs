using System;

namespace Imitation.Elements
{
	public class Sink : Collector
	{
		public override void Collect()
		{
			this.Ready();
		}
	}
}
