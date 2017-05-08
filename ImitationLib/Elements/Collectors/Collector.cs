using ImitationLib.Utils;

namespace ImitationLib.Elements
{
	public abstract class Collector : Element
	{
		public virtual void Enter(Transact transact)
		{
			this.Transact = transact;
			this.Next = this.Delay;
		}

		public override void Process(int time)
		{
			this.Transact.LifeTime = "Processed in Collector at " + time;
			System.Console.WriteLine(this.Transact);
			this.Transact = null;
			this.Next = -1;
		}
	}
}
