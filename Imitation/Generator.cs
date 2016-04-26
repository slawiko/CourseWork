using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Timers;
using System.Threading.Tasks;

namespace Imitation
{
    public class Generator 
    {
        public delegate void AfterCreateTransact(Transact transact);

        public event AfterCreateTransact CreationTransactEvent;

        private double _interval;

        public Generator(double interval)
        {
            this._interval = interval;
        }

        public void StartGenerator()
        {
            Transact transact = new Transact(new Random());
            if (CreationTransactEvent != null)
            {
                Console.WriteLine("Generator creates transact {0}", transact);
                CreationTransactEvent(transact);
            }
        }
    }
}
