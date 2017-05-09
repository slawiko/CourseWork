using ImitationLib.Utils;

namespace ImitationLib.Elements
{
	/// <summary>
	/// <see cref="IEnterable"/> interface is aplicable for those <see cref="Element"/> in which <see cref="Transact"/> can <see cref="Enter"/>
	/// </summary>
	public interface IEnterable
	{
		void Enter(Transact transact);
	}
}