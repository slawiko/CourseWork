namespace Imitation.Elements
{
	public abstract class Executor : Element, ITaker, IGiver
	{
		public abstract void Enter(Transact transact);
		public abstract Transact Exit();
	}
}

