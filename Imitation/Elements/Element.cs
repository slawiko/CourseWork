namespace Imitation.Elements
{
	public abstract class Element
	{
		public delegate void NextElement(Transact transact);
		public virtual event NextElement Next;
		public virtual System.Collections.Generic.Queue<Transact> Transacts { get; set; }
		public virtual bool ReadyToGive { get; set; }
		//public virtual bool ReadyToTake { get; set; }
		public virtual void Update()
		{
			this.ReadyToGive = this.Transacts.Count > 0 ? true : false;
		}
		public virtual void Continue()
		{
			System.Console.WriteLine(this + " call Continue");
			this.Next.Invoke(this.Transacts.Dequeue());
			this.Update();
		}
	}
}
