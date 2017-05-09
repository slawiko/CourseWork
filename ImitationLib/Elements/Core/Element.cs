using ImitationLib.Utils;

namespace ImitationLib.Elements.Core
{
	/// <summary>
	/// Using this delegate <see cref="Element"/> can pass his <see cref="ImitationLib.Utils.Transact"/> to next <see cref="Element"/>
	/// </summary>
	/// <param name="transact"></param>
	public delegate void Out(Transact transact, int time);

	/// <summary>
	/// Not implemented
	/// </summary>
	public delegate Transact In(int time);

	public abstract class Element
	{
		public virtual Out Out { get; set; }

		/// <summary>
		/// Contains <see cref="ImitationLib.Utils.Transact"/> that is on processing in current <see cref="Element"/>
		/// </summary>
		public virtual Transact Transact { get; protected set; }

		/// <summary>
		/// Represents number of <see cref="Model.Time"/> during which current <see cref="Element"/> will process <see cref="Transact"/>
		/// </summary>
		/// <remarks>
		/// <para>Value can be <see cref="Constants.DefaultReadyIn"/> if element didn't start processing</para>
		/// <para>Value can be 0 if <see cref="Element"/> is ready for taking new <see cref="Transact"/></para>
		/// <para>Value can be more than 0 and less than <see cref="Delay"/> if <see cref="Element"/> is in processing now</para>
		/// <para>Otherwise value is equal to <see cref="Delay"/></para>
		/// </remarks>
		protected int _readyIn;

		public virtual int ReadyIn
		{
			get { return this._readyIn; }
			set { this._readyIn = value != 0 ? value : this.Delay; }
		}

		/// <summary>
		/// Represents number of <see cref="Model.Time"/> required for processing
		/// </summary>
		public virtual int Delay { get; protected set; }

		/// <summary>
		/// Processes <see cref="Transact"/>
		/// </summary>
		/// <param name="time"><see cref="Model.Time"/> when <see cref="Transact"/> entered <see cref="Element"/></param>
		public virtual void Process(int time)
		{
			this.Transact.LifeTime = $"{this.Transact} is processed in {this} at {time}";
		}
	}
}