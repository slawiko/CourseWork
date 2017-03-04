namespace Imitation.Elements
{
	public abstract class Collector : Element, ITaker
	{
<<<<<<< HEAD
		public event NextElement FNext = null;
		public abstract void Collect(Transact transact);
		public override void Continue()
=======
		public event TakeDelegate ReadyTotake;
		public virtual void Take(Transact transact)
>>>>>>> rebuilding
		{
			Transacts.Enqueue(transact);
			Process();
		}
	}
}
