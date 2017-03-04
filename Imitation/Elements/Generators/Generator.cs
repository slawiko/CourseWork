namespace Imitation.Elements
{
	public abstract class Generator : Element, IGiver
	{
		public event GiveDelegate ReadyToGive;
		public virtual void Give()
		{
			if (ReadyToGive != null)
			{
				ReadyToGive(Transacts.Dequeue());
			}
		}
	}
}
