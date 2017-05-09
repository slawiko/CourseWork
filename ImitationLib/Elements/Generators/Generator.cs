using ImitationLib.Utils;

namespace ImitationLib.Elements
{
	public abstract class Generator : Element, IExitable
	{
		public virtual Transact Exit()
		{
			var transact = this.Transact;
			this.Transact = null;
			this.ReadyIn = 0;
			return transact;
		}

		public override void Process(int time)
		{
			this.Transact = new Transact();
			this.Transact.LifeTime = $"{this.Transact} is processed in {this} at {time}";
			// TODO: think about it
			var temp = this.Exit();
			try
			{
				this.Out(temp);
			}
			catch (System.Exception)
			{
				Logger.Log.Error($"{temp}skipped by {this}");
			}
		}
	}
}
