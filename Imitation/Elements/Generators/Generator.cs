namespace Imitation.Elements
{
	public abstract class Generator : Element
	{
		public abstract void Generate();
		public virtual Transact Create()
		{
			return new Transact(new System.Random(42));
		}
	}
}
