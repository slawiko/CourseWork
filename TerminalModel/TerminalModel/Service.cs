using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Timers;
using System.Threading.Tasks;

namespace Imitation
{
    class Service
    {
        public delegate void AfterLeaveService(Transact transact);
        public delegate void AfterEnterService(); 

        public event AfterLeaveService LeaveServiceEvent;
        public event AfterEnterService EnterServiceEvent;

        private double _serviceTime;
        private Transact _transact;

        public Service(double serviceTime)
        {
            this._serviceTime = serviceTime;
            EnterServiceEvent += LeaveService;
        }

        public void EnterService(Transact transact)
        {
            this._transact = transact;
            Console.WriteLine("Transact {0} enters service window", _transact);
            if (EnterServiceEvent != null) EnterServiceEvent();
        }

        public void LeaveService()
        {
            if (LeaveServiceEvent != null)
            {
                Console.WriteLine("Transact {0} leave service window", _transact);
                LeaveServiceEvent(this._transact);
            }
        }
    }
}
