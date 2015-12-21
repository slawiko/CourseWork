using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imitation.StaticElement
{
    public class Queue
    {
        public delegate void AfterLeaveQueue(Transact transact);

        public delegate void AfterEnterQueue();// I think this field is reduntant 

        public event AfterLeaveQueue LeaveQueueEvent;
        public event AfterEnterQueue EnterQueueEvent;// I think this field is reduntant 

        private Queue<Transact> _queue;

        public Queue()
        {
            this._queue = new Queue<Transact>();
            EnterQueueEvent += LeaveQueue;
        }

        public void EnterQueue(Transact transact)
        {
            this._queue.Enqueue(transact);
            Console.WriteLine("Transact {0} enters queue", _queue.Peek());
            if (EnterQueueEvent != null) EnterQueueEvent();
        }

        public void LeaveQueue()
        {
            //            while (this._queue.Count > 0)
            //            {
            //                if (LeaveQueueEvent != null) LeaveQueueEvent(this._queue.Dequeue());
            //            }

            if (LeaveQueueEvent != null && this._queue.Count > 0)
            {
                Console.WriteLine("Transact {0} leaves queue", _queue.Peek());
                LeaveQueueEvent(this._queue.Dequeue());
            }
        }
    }
}
