using System.Collections.Generic;
using ImitationLib.Utils;

namespace ImitationLib.Elements.Core
{
	public abstract class QueueableElement : Element
	{
		/// <summary>
		/// Contains <see cref="ImitationLib.Utils.Transact"/> which is on processing in current <see cref="Element"/>
		/// </summary>
		protected virtual Queue<Transact> Transacts { get; set; }

		/// <summary>
		/// Number of <see cref="Transact"/> that can be IN <see cref="Element"/>
		/// </summary>
		protected int _capacity = Constants.InfiniteQueueCapacity;

		/// <summary>
		/// Processes <see cref="Transact"/>
		/// </summary>
		/// <param name="time"><see cref="Model.Time"/> when <see cref="Transact"/> entered <see cref="Element"/></param>
		public override void Process(int time)
		{
			var temp = this.Transacts.Peek();
			temp.LifeTime = $"{temp} is processed in {this} at {time}";
		}

		protected virtual void UpdateReadiness()
		{
			if (this.Transacts.Count > 0)
			{
				this.ReadyIn = this.ReadyIn == Constants.ReadyToTake ? this.Delay : this.ReadyIn;
			}
			else
			{
				this.ReadyIn = Constants.ReadyToTake;
			}
		}
	}
}