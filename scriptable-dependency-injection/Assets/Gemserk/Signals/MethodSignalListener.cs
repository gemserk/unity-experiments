using System;

namespace Gemserk.Signals
{
	public class MethodSignalListener : ISignalListener
	{
		readonly ISignalChannel _channel;

		readonly Action<object> _callback;

		bool _listening;

		public MethodSignalListener(ISignalChannel channel, Action<object> callback)
		{
			_channel = channel;
			_callback = callback;
			StartListening ();
		}

		#region SignalListener implementation

		public void OnSignal (object t)
		{
			_callback (t);
		}

		#endregion

		public void StartListening()
		{
			if (_listening)
				return;
			_channel.StartListening (this);
			_listening = true;
		}

		public void StopListening()
		{
			if (!_listening)
				return;
			_channel.StopListening (this);
			_listening = false;
		}

	}
}
