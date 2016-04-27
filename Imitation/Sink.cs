using System;

namespace Imitation
{
	class Sink
	{
		public void CollectInfo(Transact transact)
		{
			Console.WriteLine("Transact {0} leave model", transact);
		}
	}
}
