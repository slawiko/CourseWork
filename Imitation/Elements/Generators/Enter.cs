using System;
using Imitation.Utils;

namespace Imitation.Elements
{
	// TODO: rename Enter class
	public class Enter : Generator
	{
		private Random random;
		private int capacity;

		public Enter(int delay, int capacity)
		{
			this.random = new Random(delay);
			this.capacity = capacity;
			this.Delay = delay;
			this.Next = delay;
		}

		public override void Process(int time)
		{
			// TODO: think about it
			if (capacity > 0)
			{
				this.Transact = new Transact(random);
				this.capacity--;
				this.Transact.LifeTime = "processed in Generator at " + time;
				// TODO: think about it
				var temp = this.Exit();
				try
				{
					this.Out(temp);
				}
				catch (Exception)
				{
					Console.WriteLine("Transact " + temp + " skipped by " + this);
//					Logger.Log.Error($"\"{temp}\" is skipped by \"{this}\"");
				}
			}
			else
			{
				this.Next = -1;
			}
		}
	}
}