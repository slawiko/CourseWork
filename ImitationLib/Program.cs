using ImitationLib.Utils;

namespace ImitationLib
{
	public class Program
	{
		public static void Main(string[] args)
		{
			Logger.InitLogger();
			Model model = new Model();
			model.Run();
		}
	}
}
