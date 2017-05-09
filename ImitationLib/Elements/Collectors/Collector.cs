using ImitationLib.Utils;

namespace ImitationLib.Elements
{
	public abstract class Collector : Element, IEnterable
	{
		public virtual void Enter(Transact transact)
		{
			this.Transact = transact;
			this.ReadyIn = this.Delay;
		}

		public override void Process(int time)
		{
			this.Transact.LifeTime = $"{this.Transact} is processed in {this} at {time}";
			this.Transact = null;
			this.ReadyIn = -1;
		}
	}
}
