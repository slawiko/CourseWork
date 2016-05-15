namespace Imitation.Elements
{
	public abstract class Element
	{
		public delegate Transact NextElement(Transact transact);
		public virtual event NextElement Next;
		public virtual bool Ready { get; set; }
		public virtual void Reset()
		{
			this.Ready = false;
		}
		public virtual bool Try()
		{
			return true;
		}
		public virtual Transact Process(Transact transact)
		{
			return transact;
		}
		public virtual Transact Run(Transact transact)
		{
			return this.Next?.Invoke(transact);
		}
	}
}
