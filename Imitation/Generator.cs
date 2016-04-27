using System;

namespace Imitation
{
	public class Generator
	{
		public delegate void AfterCreateTransact(Transact transact);

		public event AfterCreateTransact CreationTransactEvent;

		private double _interval;

		public Generator(double interval)
		{
			this._interval = interval;
		}

		public void StartGenerator()
		{
			Transact transact = new Transact(new Random());
			if (CreationTransactEvent != null)
			{
				Console.WriteLine("Generator creates transact {0}", transact);
				CreationTransactEvent(transact);
			}
		}
    }
}
