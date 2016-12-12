namespace Imitation
{
	public class Transact
	{
		public int Data;
		public double Time
		{
			get { return _time; }
			set { _time += value; }
		}
		private double _time;

		public string History
		{
			get { return _history; }
			set { _history = value; }
		}
		private string _history;

		public Transact(System.Random random)
		{
			_time = 0;
			Data = random.Next(1, 100);
		}

		public override string ToString()
		{
			return "History: " + History + "\nData: " + Data;
		}
	}
}
