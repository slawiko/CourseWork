using ImitationLib.Utils;

namespace ImitationLib.Elements.Core
{
	public abstract class Executor : Element, ITaker, IExitable
	{
		public virtual void Take(Transact transact, int time)
		{
			// TODO: #6
			if (this.Transact != null)
			{
				Logger.Log.Warn($"{this} is busy at {time}");
				throw new System.Exception($"{transact} is skipped by {this} at {time}, because of {this.Transact}");
			}
			this.Transact = transact;
			this.Transact.LifeTime = $"{this.Transact} is taken in {this} at {time}";
			this.ReadyIn = this.Delay;
		}

		/// <summary>
		/// Makes <see cref="Transact"/> leave <see cref="Executor"/>
		/// </summary>
		/// <returns>Released <see cref="Transact"/></returns>
		public virtual Transact Exit(int time)
		{
			var transact = this.Transact;
			transact.LifeTime = $"{transact} left {this} at {time}";
			this.Transact = null;
			this.ReadyIn = Constants.DefaultReadyIn;
			return transact;
		}

		/// <summary>
		/// <seealso cref="Element.Process"/>
		/// </summary>
		/// <param name="time"></param>
		public override void Process(int time)
		{
			base.Process(time);
			// TODO: #6
			var temp = this.Exit(time);
			try
			{
				this.Out(temp, time);
			}
			catch (System.Exception e)
			{
				Logger.Log.Error(e.Message);
			}
		}
	}
}
