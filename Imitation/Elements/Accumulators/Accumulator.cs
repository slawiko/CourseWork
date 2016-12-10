namespace Imitation.Elements
{
	public abstract class Accumulator : Element, ITaker, IGiver
	{
		public event TakeDelegate ReadyTotake;
		public abstract void Take(Transact transact);

		public event GiveDelegate ReadyToGive;
		public abstract Transact Give();
	}
}
