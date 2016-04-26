using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Timers;
using System.Threading.Tasks;

namespace Imitation
{
    public class Service : StaticElement
    {
        private Transact _transact;

        public Service(double delay)
        {
            this.Delay = delay;
            EnterEvent += Leave;
        }

        public override void Enter(Transact transact)
        {
            this._transact = transact;
            Console.WriteLine("Transact {0} enters service window", this._transact);
            OnEnter();
        }

        public override void Leave()
        {
            Console.WriteLine("Transact {0} leave service window", this._transact);
            OnLeave(this._transact);
        }
    }
}
