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

		public void Trigger(object signal)
		{
			foreach (var handler in _listeners) {
				handler.OnSignal (signal);
			}
		}

		public void Register(ISignalListener listener)
		{
			_listeners.Add (listener);
		}

		public void Unregister(ISignalListener listener)
		{
			_listeners.Remove (listener);
		}
	}
}