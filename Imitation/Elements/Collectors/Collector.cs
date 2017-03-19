namespace Imitation.Elements
{
	public abstract class Collector : Element
	{
		public virtual void Enter(Transact transact)
		{
			this.Transact = transact;
			this.Next = this.Delay;
		}

		public new virtual void Process(int time)
		{
			this.Transact.Time = time;
			this.Next = 0;
			// TODO: to think about it
			this.Transact = null;
		}
	}
}
