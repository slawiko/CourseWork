using ImitationLib.Utils;

namespace ImitationLib.Elements
{
	public delegate void Out(Transact transact);

	public abstract class Element
	{
		public virtual Out Out { get; set; }

		public virtual Transact Transact { get; protected set; }

		protected int _readyIn;

		public virtual int ReadyIn
		{
			get { return this._readyIn; }
			set { this._readyIn = value != 0 ? value : this.Delay; }
		}

		public virtual int Delay { get; protected set; }

		public virtual void Process(int time)
		{
			this.Transact.LifeTime = $"processed in {this} at {time}";
		}
	}
}