using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imitation
{
    public class Program
    {
        public static void Main(string[] args)
        {
            List<StaticElement> staticElements = new List<StaticElement>
            {
                new StaticElement(),
                new StaticElement(),
                new StaticElement()
            };

            Model model = new Model(staticElements, new Generator());
            
            System.Console.WriteLine("The end");
            System.Console.ReadKey();
        }
    }
}
