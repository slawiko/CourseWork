namespace Imitation.Elements
{
	// TODO: rename Enter class
	public class Enter : Generator
	{
		private System.Random random;

		public Enter(int delay)
		{
			this.random = new System.Random(delay);
			this.Delay = delay;
			this.Next = delay;
		}

		public override void Process(int time)
		{
			this.Transact = new Transact(random);
			this.Out(this.Exit());
		}
	}
}
