namespace Imitation.Elements
{
	public abstract class Generator : Element, IGiver
	{
		public abstract void Generate();
		public event GiveDelegate ReadyToGive;
		public Transact Give()
		{
			throw new System.NotImplementedException();
		}
	}
}
