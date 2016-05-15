namespace Imitation.Elements
{
	public class Enter : Generator
	{
		private int _num;
		private double _delay;
		//private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

		public Enter()
		{
			this._num = 1;
			this._delay = 0;
			this.Count = 0;
		}

		public Enter(int num)
		{
			this._num = num > 0 ? num : 1;
			this._delay = 0;
			this.Count = 0;
		}

		public Enter(double delay)
		{
			this._num = 1;
			this._delay = delay > 0 ? delay : 0;
			this.Count = 0;
		}

		public Enter(int num, double delay)
		{
			this._num = num > 0 ? num : 1;
			this._delay = delay > 0 ? delay : 0;
			this.Count = 0;
		}

		public override Transact Generate()
		{
			if (this.Try())
			{
				this.Count++;
				//log.Info(System.Reflection.MethodInfo.GetCurrentMethod() + " ready");
				System.Console.WriteLine(System.Reflection.MethodInfo.GetCurrentMethod() + " ready");
				this.Ready = true;
				return this.Create();
			}
			else
			{
				return null;
			}
		}

		public override Transact Create()
		{
			return new Transact(new System.Random(42));
		}

		public override bool Try()
		{
			return this.Count <= this._num;
		}
	}
}
