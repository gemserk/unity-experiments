using System.Collections.Generic;

namespace Gemserk.Signals
{
	public class SignalChannel: ISignalChannel
	{
		readonly List<ISignalListener> _listeners = new List<ISignalListener>();

		void OnDisable()
		{
			_listeners.Clear ();
		}

		public void Signal(object signal)
		{
			foreach (var handler in _listeners) {
				handler.OnSignal (signal);
			}
		}

		public void StartListening(ISignalListener listener)
		{
			_listeners.Add (listener);
		}

		public void StopListening(ISignalListener listener)
		{
			_listeners.Remove (listener);
		}
	}
}