namespace Imitation.Elements
{
	public abstract class Collector : Element, ITaker
	{
		public event TakeDelegate ReadyTotake;
		public virtual void Take(Transact transact)
		{
			Transacts.Enqueue(transact);
			Process();
		}
	}
}
