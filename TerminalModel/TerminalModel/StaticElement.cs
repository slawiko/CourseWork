using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imitation
{
    public class StaticElement
    {
        private Transact transact;

        public void doTake(Transact transaсt)
        {
            this.transact = transaсt;
        }

        public void doDo()
        {
            this.transact.data++;
        }

        public Transact doGive()
        {
            return this.transact;
        }
    }
}
