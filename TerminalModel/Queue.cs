using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imitation
{
    public class Queue : StaticElement
    {
        private Queue<Transact> _queue;

        public Queue(double delay)
        {
            this._queue = new Queue<Transact>();
            this.Delay = delay;
            EnterEvent += Leave;
        }

        public override void Enter(Transact transact)
        {
            this._queue.Enqueue(transact);
            Console.WriteLine("Transact {0} enters queue", _queue.Peek());
            OnEnter();
            
        }

        public override void Leave()
        {
            if (this._queue.Count > 0)
            {
                Console.WriteLine("Transact {0} leaves queue", this._queue.Peek());
                OnLeave(this._queue.Dequeue());
            }
        }
    }
}
