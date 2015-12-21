using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Timers;
using System.Threading.Tasks;

namespace Imitation.StaticElement
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
            //Timer timer = new Timer();

            //            while (true)
            //            {
            //                timer.Start();
            //                Transact transact = new Transact();
            //                if (CreationTransactEvent != null) CreationTransactEvent(transact);
            //            }

//            Console.WriteLine("Timer in generator starts");
//            timer.Start();
//            Console.WriteLine("Timer in generator ends");

            Transact transact = new Transact(new Random());
            if (CreationTransactEvent != null)
            {
                Console.WriteLine("Generator creates transact {0}", transact);
                CreationTransactEvent(transact);
            }
        }
    }
}
