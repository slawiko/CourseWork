namespace Imitation.Elements
{
	public abstract class Collector : Element
	{
		public event NextElement Next = null;
		public abstract Transact Collect(Transact transact);
	}
}
