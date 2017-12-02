using System;

namespace Gemserk.Signals
{
	public class MethodSignalListener : ISignalListener
	{
		readonly ISignalChannel _channel;

		readonly Action<object> _callback;

		public MethodSignalListener(ISignalChannel channel, Action<object> callback)
		{
			_channel = channel;
			_callback = callback;
		}

		#region SignalListener implementation

		public void OnSignal (object t)
		{
			_callback (t);
		}

		#endregion

		public void StartListening()
		{
			_channel.StartListening (this);
		}

		public void StopListening()
		{
			_channel.StopListening (this);
		}

	}
}
