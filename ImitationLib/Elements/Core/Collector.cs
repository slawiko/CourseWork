using System.Collections.Generic;
using ImitationLib.Utils;

namespace ImitationLib.Elements.Core
{
	public abstract class Collector : Element, ITaker
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
			this.Transact = transact;
			this.Transact.LifeTime = $"{this.Transact} is taken in {this} at {time}";
			this.ReadyIn = this.Delay;
		}

		/// <summary>
		/// <seealso cref="Element.Process"/>
		/// </summary>
		/// <param name="time"></param>
		public override void Process(int time)
		{
			base.Process(time);
			this.CollectedTransacts.Add(this.Transact);
			this.ReadyIn = Constants.DefaultReadyIn;
		}
	}
}
