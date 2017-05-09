using ImitationLib.Utils;

namespace ImitationLib.Elements.Core
{
	/// <summary>
	/// <see cref="IGiver"/> interface is aplicable for those <see cref="Element"/> from which <see cref="Transact"/> can <see cref="Give"/>
	/// </summary>
	public interface IGiver
	{
		/// <summary>
		/// Gives <see cref="Transact"/> to next <see cref="Element"/>
		/// </summary>
		Transact Give(int time);
	}
}