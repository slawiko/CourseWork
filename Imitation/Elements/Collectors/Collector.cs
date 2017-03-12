namespace Imitation.Elements
{
	public abstract class Collector : Element, ITaker
	{
		public abstract void Enter(Transact transact);
	}
}
