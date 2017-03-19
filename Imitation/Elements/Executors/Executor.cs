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
			this.Next = 0;
			return this.Transact;
		}

		public override void Process(int time)
		{
			this.Transact.Time = time;
			this.Out(this.Exit());
		}
	}
}
