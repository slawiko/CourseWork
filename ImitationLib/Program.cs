using ImitationLib.Elements;
using ImitationLib.Utils;

namespace ImitationLib
{
	public class Program
	{
		public static void Main(string[] args)
		{
			Logger.InitLogger();

			Entrance entrance = new Entrance(5, 4);
			Service service = new Service(12, 1);
			Service service2 = new Service(2, 1);
			Service service3 = new Service(8, 1);
			Exit exit = new Exit(0);

			Model model = new Model();
			model.LinkElements(entrance, exit, service, service2, service3);
			model.Run();
		}
	}
}
