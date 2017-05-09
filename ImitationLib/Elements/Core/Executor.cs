using ImitationLib.Utils;

namespace ImitationLib.Elements.Core
{
	public abstract class Executor : Element, IEnterable, IExitable
	{
		public virtual void Enter(Transact transact)
		{
			if (this.Transact != null)
			{
				Logger.Log.Warn($"{this} is busy");
				throw new System.Exception($"{transact} is skipped by {this}, because of {this.Transact}");
			}
			this.Transact = transact;
			this.ReadyIn = this.Delay;
		}

		public virtual Transact Exit()
		{
			var transact = this.Transact;
			this.Transact = null;
			this.ReadyIn = Constants.DefaultReadyIn;
			return transact;
		}

		public override void Process(int time)
		{
			this.Transact.LifeTime = $"{this.Transact} is processed in {this} at {time}";
			// TODO: think about it
			var temp = this.Exit();
			try
			{
				this.Out(temp);
			}
			catch (System.Exception e)
			{
				Logger.Log.Error(e.Message);
			}
		}
	}
}
