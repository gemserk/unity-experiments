using System;

namespace Gemserk.Signals
{
	public class MethodSignalListenerGeneric<T> : ISignalListenerGeneric<T> where T : class 
	{
		readonly ISignalChannelGeneric<T> _channel;

		readonly Action<T> _callback;

		bool _listening;

		public MethodSignalListenerGeneric(ISignalChannelGeneric<T> channel, Action<T> callback)
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

	public class MethodSignalListener : MethodSignalListenerGeneric<object>
	{
		public MethodSignalListener(ISignalChannelGeneric<object> channel, Action<object> callback) 
			:base(channel, callback)
		{
			
		}
	}
}
