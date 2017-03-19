namespace Imitation.Elements
{
	public abstract class Executor : Element
	{
		public virtual void Enter(Transact transact)
		{
			this.Transact = transact;
			this.Next = this.Delay;
		}

		public virtual Transact Exit()
		{
			return this.Transact;
		}

		public override void Process(int time)
		{
			this.Transact.Time = time;
			this.Next = 0;
			this.Out(this.Exit());
		}
	}
}
