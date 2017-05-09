using ImitationLib.Utils;

namespace ImitationLib.Elements.Core
{
	/// <summary>
	/// <see cref="IExitable"/> interface is aplicable for those <see cref="Element"/> from which <see cref="Transact"/> can <see cref="Exit"/>
	/// </summary>
	public interface IExitable
	{
		Transact Exit();
	}
}