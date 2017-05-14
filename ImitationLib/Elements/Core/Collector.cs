using System;
using ImitationLib.Utils;

namespace ImitationLib.Elements.Core
{
	public abstract class Collector : Element, ITaker
	{
		/// <summary>
		/// <seealso cref="ITaker.Take"/>
		/// </summary>
		/// <param name="transact"></param>
		/// <param name="time"></param>
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
		/// Collects <see cref="Transact"/>
		/// </summary>
		protected virtual void Collect() {}

		/// <summary>
		/// <seealso cref="Element.Process"/>
		/// </summary>
		/// <param name="time"></param>
		public override void Process(int time)
		{
			base.Process(time);
			this.Transacts.Dequeue();
			this.ReadyIn = this.Transacts.Count > 0 ? this.Delay : Constants.ReadyToTake;
		}
	}
}
