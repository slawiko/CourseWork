using System;
using System.Collections.Generic;
using ImitationLib.Utils;

namespace ImitationLib.Elements.Core
{
	public abstract class Collector : QueueableElement, ITaker
	{
		/// <summary>
		/// List of <see cref="Transact"/> that left <see cref="Model"/>
		/// </summary>
		public virtual List<Transact> CollectedTransacts { get; protected set; }

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
			this.UpdateReadiness();
		}

		/// <summary>
		/// <seealso cref="Element.Process"/>
		/// </summary>
		/// <param name="time"></param>
		public override void Process(int time)
		{
			base.Process(time);
			this.CollectedTransacts.Add(this.Transacts.Dequeue());
			this.UpdateReadiness();
		}
	}
}
