namespace Imitation.Elements
{
	public abstract class Collector : Element
	{
		public virtual void Enter(Transact transact)
		{
			this.Transact = transact;
			this.Next = this.Delay;
		}

		public override void Process(int time)
		{
			this.Transact.Time = time;
			// TODO: to think about it
			this.Transact = null;
		}
	}
}
