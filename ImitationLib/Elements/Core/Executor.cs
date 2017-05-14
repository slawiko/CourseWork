using System;
using ImitationLib.Utils;

namespace ImitationLib.Elements.Core
{
	public abstract class Executor : Element, ITaker, IGiver
	{
		/// <summary>
		/// <seealso cref="ITaker.Take"/>
		/// </summary>
		/// <param name="transact"></param>
		/// <param name="time"></param>
		/// <exception cref="Exception"></exception>
		public virtual void Take(Transact transact, int time)
		{
			if (this._capacity != Constants.InfiniteQueueCapacity && this.Transacts.Count >= this._capacity)
			{
				Logger.Log.Warn($"{this} is overcrowded at {time}");
				throw new Exception($"{transact} is skipped by {this} at {time}, because of overcrowding");
			}
			transact.LifeTime = $"{transact} is taken in {this} at {time}";
			this.Transacts.Enqueue(transact);
			this.ReadyIn = this.ReadyIn == Constants.ReadyToTake ? this.Delay : this.ReadyIn;
		}

		/// <summary>
		/// <seealso cref="IGiver.Give"/>
		/// </summary>
		/// <param name="time"></param>
		/// <returns>Given <see cref="Transact"/></returns>
		public virtual Transact Give(int time)
		{
			var transact = this.Transacts.Dequeue();
			this.ReadyIn = this.Transacts.Count > 0 ? this.Delay : Constants.ReadyToTake;
			transact.LifeTime = $"{transact} is given by {this} at {time}";
			return transact;
		}

		/// <summary>
		/// <seealso cref="Element.Process"/>
		/// </summary>
		/// <param name="time"></param>
		/// <exception cref="Exception"></exception>
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
