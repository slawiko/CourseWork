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
			// TODO: #6
			if (this.Transact != null)
			{
				Logger.Log.Warn($"{this} is busy at {time}");
				throw new Exception($"{transact} is skipped by {this} at {time}, because of {this.Transact}");
			}
			this.Transact = transact;
			this.Transact.LifeTime = $"{this.Transact} is taken in {this} at {time}";
			this.ReadyIn = this.Delay;
		}

		/// <summary>
		/// <seealso cref="IGiver.Give"/>
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
			catch (Exception e)
			{
				Logger.Log.Error(e.Message);
			}
		}
	}
}
