namespace Imitation.Elements
{
	public abstract class Element
	{
		public delegate void NextElement();
		public virtual event NextElement Next;

		public virtual void Ready()
		{
			this.Next?.Invoke();
		}
	}
}
