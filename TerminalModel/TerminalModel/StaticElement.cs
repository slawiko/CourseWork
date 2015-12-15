using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imitation
{
    class StaticElement
    {
        private Transact transact;

        public void doTake(Transact transaсt)
        {
            this.transact = transaсt;
        }

        public bool doDo()
        {
            return this.transact.toChange();
        }

        public Transact doGive()
        {
            return this.transact;
        }
    }
}
