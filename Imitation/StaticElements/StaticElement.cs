namespace Imitation.Elements
{
	public abstract class Element
	{
		public delegate void AfterLeave(Transact transact);
		public event AfterLeave LeaveEvent;
		protected double Delay;

		public abstract void Enter(Transact transact);

		protected virtual void OnLeave(Transact transact)
		{
			if (LeaveEvent != null) LeaveEvent(transact);
		}
	}
}
