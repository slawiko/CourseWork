namespace Imitation.Elements
{
	public abstract class Collector : Element, ITaker
	{
		public event TakeDelegate ReadyTotake;
		public void Take(Transact transact)
		{
			throw new System.NotImplementedException();
		}
	}
}
