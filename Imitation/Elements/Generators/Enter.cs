namespace Imitation.Elements
{
	// TODO: rename Enter class
	public class Enter : Generator
	{
		public Enter(int delay)
		{
			var random = new System.Random(2);
			this.Transact = new Transact(random);
			this.Delay = delay;
			this.Next = delay;
		}
	}
}
