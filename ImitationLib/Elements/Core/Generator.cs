using System;
using ImitationLib.Utils;

namespace ImitationLib.Elements.Core
{
	public abstract class Generator : Element, IGiver
	{
		/// <summary>
		/// List of <see cref="Transact"/> that will enter in <see cref="Model"/>
		/// </summary>
		protected Transact Transact { get; set; }

		/// <summary>
		/// <seealso cref="IGiver.Give"/>
		/// </summary>
		/// <param name="time"></param>
		/// <returns></returns>
		public virtual Transact Give(int time)
		{
			var transact = this.Transact;
			transact.LifeTime = $"{transact} is given by {this} at {time}";
			this.Transact = null;
			this.ReadyIn = 0;
			return transact;
		}

		/// <summary>
		/// <seealso cref="Element.Process"/>
		/// </summary>
		/// <param name="time"></param>
		/// <exception cref="Exception"></exception>
		public override void Process(int time)
		{
			this.Transact = new Transact();
			this.Transact.LifeTime = $"{this.Transact} is processed in {this} at {time}";
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
