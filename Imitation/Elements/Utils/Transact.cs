using System.Collections.Generic;

namespace Imitation
{
	public class Transact
	{
		private int _data;
		private List<int> _time;
		public int Time
		{
			get { return this._time[this._time.Count - 1]; }
			set { this._time.Add(value); }
		}

		public Transact()
		{
			this._time = new List<int>();
			this._data = -1;
		}
		public Transact(System.Random random)
		{
			this._time = new List<int>();
			this._data = random.Next(1, 100);
		}

		public override string ToString()
		{
			return "Time: " + this._time.ToString() + "\nData: " + this._data;
		}
	}
}
