using ImitationLib.Utils;

namespace ImitationLib.Elements.Core
{
	/// <summary>
	/// <see cref="ITaker"/> interface is aplicable for those <see cref="Element"/> in which <see cref="Transact"/> can <see cref="Take"/>
	/// </summary>
	public interface ITaker
	{
		/// <summary>
		/// Takes <see cref="Transact"/> from previous <see cref="Element"/>
		/// </summary>
		void Take(Transact transact, int time);
	}
}