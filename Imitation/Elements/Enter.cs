namespace Imitation.Elements
{
	public class Enter : Generator
	{
		private int _num;
		private double _delay;

		public Enter()
		{
			this._num = 1;
			this._delay = 0;
		}

		public Enter(int num)
		{
			this._num = num > 0 ? num : 1;
			this._delay = 0;
		}

		public Enter(double delay)
		{
			this._num = 1;
			this._delay = delay > 0 ? delay : 0;
		}

		public Enter(int num, double delay)
		{
			this._num = num > 0 ? num : 1;
			this._delay = delay > 0 ? delay : 0;
		}

		public override void Generate()
		{
			for (var i = 0; i < this._num; i++)
			{
				System.Console.WriteLine("Enter ready");
				this.Ready();
			}
		}
	}
}
