using ImitationLib.Utils;

namespace ImitationLib.Elements.Core
{
	public abstract class Executor : Element, ITaker, IGiver
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
		/// Gives <see cref="Transact"/> to next <see cref="Element"/>
		/// </summary>
		/// <returns>Given <see cref="Transact"/></returns>
		public virtual Transact Give(int time)
		{
			var transact = this.Transact;
			transact.LifeTime = $"{transact} is given by {this} at {time}";
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
			var temp = this.Give(time);
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
