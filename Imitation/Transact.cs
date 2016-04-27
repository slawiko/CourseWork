using System;

namespace Imitation
{
	public class Transact
	{
		public int Data;

		public Transact(Random random)
		{
			this.Data = random.Next(1, 100);
		}

		public override string ToString()
		{
			return this.Data.ToString();
		}
	}
}
