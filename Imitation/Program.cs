namespace Imitation
{
	public class Program
	{
		private static readonly log4net.ILog log = 
					log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

		public static void Main(string[] args)
		{
			Model model = new Model();

			System.Console.ReadKey();
		}
	}
}
