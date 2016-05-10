namespace Imitation.Elements
{
	public class Enter : Generator
	{
		private double _delay;

		public Enter(double delay)
		{
			this._delay = delay;
		}

		public override void Generate()
		{
			for (var i = 0; i < 7; i++)
			{
				this.Ready();
			}
		}
	}
}
