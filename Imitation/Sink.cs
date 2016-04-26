using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imitation
{
    class Sink
    {
        public void CollectInfo(Transact transact)
        {
            Console.WriteLine("Transact {0} leave model", transact);
        }
    }
}
