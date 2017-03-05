using System;

namespace Imitation.Elements
{
	public sealed class Enter : Generator
	{
		Enter(int delay)
		{
			this.Next = delay;
		}

		public override int Next
		{
			get
			{
				throw new NotImplementedException();
			}

			protected set
			{
				throw new NotImplementedException();
			}
		}

		protected override Transact Transact
		{
			get
			{
				throw new NotImplementedException();
			}

			set
			{
				throw new NotImplementedException();
			}
		}

		public override Transact Exit()
		{
			throw new NotImplementedException();
		}

		public override void Process()
		{
			throw new NotImplementedException();
		}
	}
}
