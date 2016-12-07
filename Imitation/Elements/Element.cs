namespace Imitation.Elements
{
	public abstract class Element
	{
		public delegate void GiveDelegate(Transact transact);
		public delegate Transact TakeDelegate();

		protected virtual System.Collections.Generic.HashSet<Transact> Transacts { get; set; }

		protected abstract void Process();
	}
}
