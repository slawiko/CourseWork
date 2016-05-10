namespace Imitation.Elements
{
	public abstract class Accumulator : Element
	{
		public abstract void Enter();
		public abstract bool IsFinite();
		public abstract bool Try();
	}
}
