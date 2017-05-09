using System;
using ImitationLib.Elements.Core;
using ImitationLib.Utils;

namespace ImitationLib.Elements
{
	// TODO: rename Enter class
	public class Enter : Generator
	{
		private readonly Random _random;
		private int capacity;

		public Enter(int delay, int capacity)
		{
			this._random = new Random(delay);
			this.capacity = capacity;
			this.Delay = delay;
			this.ReadyIn = delay;
		}

		public override void Process(int time)
		{
			// TODO: think about it
			if (capacity > 0)
			{
				this.Transact = new Transact(_random);
				this.capacity--;
				this.Transact.LifeTime = $"{this.Transact} is processed in {this} at {time}";
				// TODO: think about it
				var temp = this.Exit();
				try
				{
					this.Out(temp);
				}
				catch (Exception e)
				{
					Logger.Log.Error(e.Message);
				}
			}
			else
			{
				this.ReadyIn = -1;
			}
		}
	}
}