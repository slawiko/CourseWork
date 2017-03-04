using System.Collections.Generic;

namespace Imitation.Elements
{
	public class Exit : Collector
	{
		public Exit()
		{
			Transacts = new Queue<Transact>();
		}
		public override void Process()
		{
			var transact = Transacts.Dequeue();
			transact.History += "Transact " + transact.Data + " leaves model.";

			System.Console.WriteLine(transact);
		}
	}
}
