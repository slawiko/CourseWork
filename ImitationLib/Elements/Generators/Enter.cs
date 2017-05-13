using System;
using ImitationLib.Elements.Core;
using ImitationLib.Utils;

namespace ImitationLib.Elements
{
	// TODO: rename Enter class
	public sealed class Enter : Generator
	{
		private readonly Random _random;
		private int _capacity;

		public Enter(int delay, int capacity)
		{
			this._random = new Random(delay);
			this._capacity = capacity;
			this.Delay = delay;
			this.ReadyIn = delay;
		}

		public override void Process(int time)
		{
			// TODO: think about it
			if (_capacity > 0)
			{
				this.Transact = new Transact(_random);
				this._capacity--;
				this.Transact.LifeTime = $"{this.Transact} is processed in {this} at {time}";
				// TODO: think about it
				var temp = this.Give(time);
				try
				{
					this.Out(temp, time);
				}
				catch (Exception e)
				{
					Logger.Log.Error(e.Message);
				}
			}
			else
			{
				this.ReadyIn = Constants.ReadyToTake;
			}
		}
	}
}