namespace Imitation.Elements
{
	public abstract class Executor : Element, ITaker, IGiver
	{
		public event TakeDelegate ReadyTotake;
		public void Take(Transact transact)
		{
			throw new System.NotImplementedException();
		}

		public event GiveDelegate ReadyToGive;
		public Transact Give()
		{
			throw new System.NotImplementedException();
		}
	}
}

