namespace Imitation.Elements
{
	public abstract class Executor : Element
	{
		public abstract Transact Execute(Transact transact);
		public virtual System.Collections.Generic.Queue<Transact> Transacts { get; set; }
	}
}

