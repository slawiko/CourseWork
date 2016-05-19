namespace Imitation.Elements
{
	public class Enter : Generator
	{
		private int _num;
		private double _delay;

		/*public Enter()
		{
			this._num = -1;
			this._delay = 0;
			this.Transacts = new System.Collections.Generic.Queue<Transact>();
			for (var i = 0; i < this._num; i++)
			{
				this.Generate();
			}
		}*/

		public Enter(int num)
		{
			this._num = num > 0 ? num : 1;
			this._delay = 0;
			this.Transacts = new System.Collections.Generic.Queue<Transact>();
			for (var i = 0; i < this._num; i++)
			{
				this.Generate();
			}
		}

		public Enter(double delay)
		{
			this._num = 1;
			this._delay = delay > 0 ? delay : 0;
			this.Transacts = new System.Collections.Generic.Queue<Transact>();
			for (var i = 0; i < this._num; i++)
			{
				this.Generate();
			}
		}

		/*public Enter(int num, double delay)
		{
			this._num = num > 0 ? num : -1;
			this._delay = delay > 0 ? delay : 0;
			this.Transacts = new System.Collections.Generic.Queue<Transact>();
			for (var i = 0; i < this._num; i++)
			{
				this.Generate();
			}
		}*/

		public override void Generate()
		{
			if (this.Try())
			{
				this.Transacts.Enqueue(this.Create());
				this.Update();
			}
			else
			{
				// TODO
			}
		}

		public bool Try()
		{
			return this.Transacts.Count <= this._num;
		}
	}
}
