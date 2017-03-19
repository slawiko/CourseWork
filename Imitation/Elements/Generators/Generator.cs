namespace Imitation.Elements
{
	public abstract class Generator : Element
	{
		public virtual Transact Exit()
		{
			return this.Transact;
		}

		public new virtual void Process(int time)
		{
			this.Transact.Time = time;
			this.Next = 0;
			this.Out(this.Exit());
		}
	}
}
