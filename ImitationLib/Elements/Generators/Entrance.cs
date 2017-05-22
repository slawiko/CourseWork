using System;
using ImitationLib.Elements.Core;
using ImitationLib.Utils;

namespace ImitationLib.Elements
{
	public sealed class Entrance : Generator
	{
		private readonly Random _random;

		public Entrance(int delay, int count) : base(delay, count)
		{
			this._random = new Random(delay);
			this.ReadyIn = delay;
		}

		public override void Process(int time)
		{
			// TODO: think about it
			this.Generate(this._random);
			var transact = this.Transacts.Peek();
			transact.LifeTime = $"{transact} is processed in {this} at {time}";
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
	}
}