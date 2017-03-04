using System.Collections.Generic;

namespace Imitation
{
	public class TransactComparer: IEqualityComparer<Transact>
	{
		public bool Equals(Transact x, Transact y)
		{
			return x.Data == y.Data;
		}

		public int GetHashCode(Transact obj)
		{
			return obj.Data.GetHashCode();
		}
	}
}