using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Timers;
using System.Threading.Tasks;

namespace Imitation.StaticElement
{
    class ServiceWindow
    {
        public delegate void AfterLeaveServiceWindow(Transact transact);

        public delegate void AfterEnterServiceWindow(); 

        public event AfterLeaveServiceWindow LeaveServiceWindowEvent;
        public event AfterEnterServiceWindow EnterServiceWindowEvent;

        private double _serviceTime;
        private Transact _transact;

        public ServiceWindow(double serviceTime)
        {
            this._serviceTime = serviceTime;
            EnterServiceWindowEvent += LeaveServiceWindow;
        }

        public void EnterServiceWindow(Transact transact)
        {
            this._transact = transact;
            Console.WriteLine("Transact {0} enters service window", _transact);
            if (EnterServiceWindowEvent != null) EnterServiceWindowEvent();
        }

        public void LeaveServiceWindow()
        {
//            Timer timer = new Timer(this._serviceTime);
//            Console.WriteLine("Timer in service window starts");
//            timer.Start();
//            Console.WriteLine("Timer in service window ends");

            if (LeaveServiceWindowEvent != null)
            {
                Console.WriteLine("Transact {0} leave service window", _transact);
                LeaveServiceWindowEvent(this._transact);
            }
        }
    }
}
