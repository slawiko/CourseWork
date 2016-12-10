namespace Imitation.Elements
{
	public abstract class Generator : Element, IGiver
	{
		public event GiveDelegate ReadyToGive;
		public abstract Transact Give();
	}
}
