namespace Imitation.Elements
{
	public abstract class Generator : Element
	{
		public abstract Transact Generate();
		public abstract Transact Create();
		public virtual int Count { get; set; }
	}
}
