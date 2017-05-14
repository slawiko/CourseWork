using System;
using System.Collections.Generic;
using ImitationLib.Elements.Core;
using ImitationLib.Utils;

namespace ImitationLib.Elements
{
	// TODO: rename Enter class
	public sealed class Enter : Generator
	{
		private readonly Random _random;

		public Enter(int delay, int count)
		{
			this._random = new Random(delay);
			this._count = count;
			this.Delay = delay;
			this.ReadyIn = delay;
			this.Transacts = new Queue<Transact>();
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