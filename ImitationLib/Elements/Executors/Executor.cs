using ImitationLib.Utils;

namespace ImitationLib.Elements
{
	public abstract class Executor : Element, IEnterable, IExitable
	{
		public virtual void Enter(Transact transact)
		{
			if (this.Transact != null)
			{
				Logger.Log.Warn($"{this} is busy");
				throw new System.Exception($"{this} is busy");
			}
			this.Transact = transact;
			this.ReadyIn = this.Delay;
		}

		public virtual Transact Exit()
		{
			var transact = this.Transact;
			this.Transact = null;
			this.ReadyIn = -1;
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
			catch (System.Exception)
			{
				Logger.Log.Error($"{temp} skipped by {this}");
			}
		}
	}
}
