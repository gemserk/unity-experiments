using System;

namespace Gemserk.Signals
{
	public class MethodSignalListener : ISignalListener
	{
		readonly Action<object> _callback;

		public MethodSignalListener(Action<object> callback)
		{
			_callback = callback;
		}

		#region SignalListener implementation

		public void OnSignal (object t)
		{
			_callback (t);
		}

		#endregion

	}
}
