namespace Imitation.Elements
{
	public interface IGiver
	{
		event Element.GiveDelegate ReadyToGive;
		Transact Give();
	}
}