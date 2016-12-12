namespace Imitation.Elements
{
	public abstract class Executor : Element, ITaker, IGiver
	{
		public event TakeDelegate ReadyTotake;
		public void Take(Transact transact)
		{
			Transacts.Enqueue(transact);
		}

		public event GiveDelegate ReadyToGive;
		public void Give()
		{
			throw new System.NotImplementedException();
		}
	}
}

