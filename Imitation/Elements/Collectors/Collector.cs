namespace Imitation.Elements
{
	public abstract class Collector : Element
	{
		public event NextElement FNext = null;
		public abstract void Collect(Transact transact);
		public override void Continue()
		{
			return;
		}
	}
}
