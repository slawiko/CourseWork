using System;
using ImitationLib.Utils;

namespace ImitationLib.Elements.Core
{
	public abstract class Executor : QueueableElement, ITaker, IGiver
	{
		/// <summary>
		/// <seealso cref="ITaker.Take"/>
		/// </summary>
		/// <param name="transact"></param>
		/// <param name="time"></param>
		/// <exception cref="Exception"></exception>
		public virtual void Take(Transact transact, int time)
		{
			if (this._capacity != Constants.InfiniteQueue && this.Transacts.Count >= this._capacity)
			{
				Logger.Log.Warn($"{this} is overcrowded at {time}");
				throw new Exception($"{transact} is skipped by {this} at {time}, because of overcrowding");
			}
			transact.LifeTime = $"{transact} is taken in {this} at {time}";
			this.Transacts.Enqueue(transact);
			this.ReadyIn = this.ReadyIn > 0 ? this.ReadyIn : this.Delay;
		}

		/// <summary>
		/// <seealso cref="IGiver.Give"/>
		/// </summary>
		/// <returns>Given <see cref="Transact"/></returns>
		public virtual Transact Give(int time)
		{
			var transact = this.Transacts.Dequeue();
			transact.LifeTime = $"{transact} is given by {this} at {time}";
			this.ReadyIn = this.Transacts.Count > 0 ? this.Delay : Constants.DefaultReadyIn;
			return transact;
		}

		/// <summary>
		/// <seealso cref="Element.Process"/>
		/// </summary>
		/// <param name="time"></param>
		public override void Process(int time)
		{
			base.Process(time);

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
