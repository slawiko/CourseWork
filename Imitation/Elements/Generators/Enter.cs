using System;
using System.Collections.Generic;

namespace Imitation.Elements
{
	public sealed class Enter : Generator
	{
		private int _num;
		private double _delay;
		private Random _random;
		//TODO: each element will have Distribution law
		//private bool Distribution;

		public Enter(int num)
		{
			Transacts = new Queue<Transact>();
			_num = num;
			_delay = -1;
			_random = new Random();
		}

		public Enter(double delay)
		{
			Transacts = new Queue<Transact>();
			_num = -1;
			_delay = delay;
			_random = new Random();
		}

		public Enter(int num, double delay)
		{
			Transacts = new Queue<Transact>();
			_num = num;
			_delay = delay;
			_random = new Random();
		}

		public override void Process()
		{
			for (var i = 0; i < _num; i++)
			{
				var transact = new Transact(_random);
				transact.History += "It's a " + i + " created transact. ";
				Transacts.Enqueue(transact);
				Give();
			}
		}
	}
}
