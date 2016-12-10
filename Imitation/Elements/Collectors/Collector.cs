namespace Imitation.Elements
{
	public abstract class Collector : Element, ITaker
	{
		public event TakeDelegate ReadyTotake;
		public abstract void Take(Transact transact);
	}
}
