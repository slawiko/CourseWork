namespace Imitation.Elements
{
	public interface ITaker
	{
		event Element.TakeDelegate ReadyTotake;
		void Take(Transact transact);
	}
}