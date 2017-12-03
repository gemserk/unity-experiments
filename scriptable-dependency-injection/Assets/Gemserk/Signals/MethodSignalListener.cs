using System;

namespace Gemserk.Signals
{
	public class MethodSignalListener<T> : ISignalListener<T> where T : class 
	{
		readonly ISignalChannel<T> _channel;

		readonly Action<T> _callback;

		bool _listening;

		public MethodSignalListener(ISignalChannel<T> channel, Action<T> callback)
		{
			_channel = channel;
			_callback = callback;
			StartListening ();
		}

		#region SignalListener implementation

		public void OnSignal (T t)
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
