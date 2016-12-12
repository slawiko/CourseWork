namespace Imitation.Elements
{
	public interface IGiver
	{
		event Element.GiveDelegate ReadyToGive;
		void Give();
	}
}