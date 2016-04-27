using System;

namespace Imitation.Elements
{
	public class Service : Element
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
