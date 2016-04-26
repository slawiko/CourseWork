using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imitation
{
    public abstract class StaticElement
    {
        public delegate void AfterLeave(Transact transact);
        public delegate void AfterEnter(); // shit

        public event AfterLeave LeaveEvent;
        public event AfterEnter EnterEvent; // shit

        protected double Delay;

        public abstract void Enter(Transact transact);
        public abstract void Leave();

        protected virtual void OnEnter() // shit
        {
            if (EnterEvent != null) EnterEvent();
        }

        protected virtual void OnLeave(Transact transact)
        {
            if (LeaveEvent != null) LeaveEvent(transact);
        }
    }
}
