namespace Imitation.Elements
{
	public abstract class Executor : Element
	{
		public virtual void Enter(Transact transact)
		{
			if (this.Transact != null)
			{
				throw new System.Exception("Element is busy");
			}
			this.Transact = transact;
			this.Next = this.Delay;
		}

		public virtual Transact Exit()
		{
			var transact = this.Transact;
			this.Transact = null;
			this.Next = -1;
			return transact;
		}

		public override void Process(int time)
		{
			this.Transact.LifeTime = "Processed in Executor at " + time;
			// TODO: think about it
			var temp = this.Exit();
			try
			{
				this.Out(temp);
			}
			catch (System.Exception)
			{
				System.Console.WriteLine(temp + " skipped by " + this);
			}
		}
	}
}
