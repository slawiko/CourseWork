using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imitation
{
    public class StaticElement // some staticElement, like Queue, checkpoint, etc.
    {
        // async/await?
        //private Queue<Transact> queue;
        private Transact _transact;

        public StaticElement()
        {
            this._transact = new Transact();
        }

        public Transact ProduceTransact(Transact transact)
        {
            this.DoTake(transact);
            this.DoDo();
            return this.DoGive();
        }

        private void DoTake(Transact transaсt)
        {
            this._transact = transaсt; // take _transact
        }

        private void DoDo()
        {
            this._transact.Data++; // change Data
        }

        private Transact DoGive()
        {
            return this._transact; // give produced(changed) _transact
        }
    }
}
