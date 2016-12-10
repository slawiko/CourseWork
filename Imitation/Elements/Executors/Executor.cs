namespace Imitation.Elements
{
	public abstract class Executor : Element, ITaker, IGiver
	{
		public event TakeDelegate ReadyTotake;
		public abstract void Take(Transact transact);

		public event GiveDelegate ReadyToGive;
		public abstract Transact Give();
	}
}

