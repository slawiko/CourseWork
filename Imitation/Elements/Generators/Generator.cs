namespace Imitation.Elements
{
	public abstract class Generator : Element
	{
		public virtual Transact Exit()
		{
			this.Next = 0;
			return this.Transact;
		}

		public override void Process(int time)
		{
			this.Transact = new Transact();
			this.Out(this.Exit());
		}
	}
}
