namespace Imitation.Elements
{
	// TODO: rename Enter class
	public class Enter : Generator
	{
		private System.Random random;
		private int capacity;

		public Enter(int delay, int capacity)
		{
			this.random = new System.Random(delay);
			this.capacity = capacity;
			this.Delay = delay;
			this.Next = delay;
		}

		public override void Process(int time)
		{
			// TODO: think about it
			if (capacity > 0)
			{
				this.Transact = new Transact(random);
				this.capacity--;
				this.Transact.LifeTime = "Processed in Generator at " + time;
				// TODO: think about it
				var temp = this.Exit();
				try
				{
					this.Out(temp);
				}
				catch (System.Exception)
				{
					System.Console.WriteLine("Transact " + temp + " skipped by " + this);
				}
			}
			else 
			{
				this.Next = -1;
			}
		}
	}
}
