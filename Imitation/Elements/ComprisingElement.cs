namespace Imitation.Elements
{
	public abstract class ComprisingElement : Element
	{
		public virtual System.Collections.Generic.Queue<Transact> Transacts { get; set; }
	}
}
