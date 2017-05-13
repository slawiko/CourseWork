using ImitationLib.Elements;
using ImitationLib.Elements.Core;
using ImitationLib.Utils;

namespace ImitationLib
{
	public class Program
	{
		public static void Main(string[] args)
		{
			Logger.InitLogger();

			Generator enter = new Enter(5, 4);
			Executor service = new Service(12, 1);
			Executor service2 = new Service(2, 1);
			Executor service3 = new Service(8, 1);
			Collector exit = new Exit(0);

			Model model = new Model();
			model.LinkElements(enter, exit, service, service2, service3);
			model.Run();
		}
	}
}
