namespace Imitation.Elements
{
	public abstract class Accumulator : Element
	{
		public abstract Transact Enter(Transact transact);
		public virtual System.Collections.Generic.Queue<Transact> Transacts { get; set; }
	}
}
