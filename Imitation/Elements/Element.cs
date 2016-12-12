namespace Imitation.Elements
{
	public abstract class Element
	{
		public delegate void GiveDelegate(Transact transact);
		public delegate Transact TakeDelegate();

		public virtual System.Collections.Generic.Queue<Transact> Transacts { get; set; }

		public abstract void Process();
	}
}
