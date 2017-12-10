using System.Collections.Generic;

namespace Gemserk.Signals
{
	public class SignalChannel<T> : ISignalChannel<T> where T : class
 	{
		readonly List<ISignalListener<T>> _listeners = new List<ISignalListener<T>>();

		void OnDisable()
		{
			_listeners.Clear ();
		}

		public void Signal(T signal)
		{
			foreach (var handler in _listeners) {
				handler.OnSignal (signal);
			}
		}

		public void StartListening(ISignalListener<T> listener)
		{
			_listeners.Add (listener);
		}

		public void StopListening(ISignalListener<T> listener)
		{
			_listeners.Remove (listener);
		}
	}
}