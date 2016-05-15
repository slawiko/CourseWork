namespace Imitation
{
	public class Transact
	{
		public int Data;
		public double Time
		{
			get { return this._time; }
			set { this._time += value; }
		}
		private double _time;

		public Transact(System.Random random)
		{
			this._time = 0;
			this.Data = random.Next(1, 100);
		}

		public override string ToString()
		{
			return this.Data.ToString();
		}
	}
}
