using System.Collections.Generic;

namespace Gemserk.Signals
{
	public class SignalChannel<T> : ISignalChannel<T> where T : class
 	{
		readonly List<ISignalListenerGeneric<T>> _listeners = new List<ISignalListenerGeneric<T>>();

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

		public void StartListening(ISignalListenerGeneric<T> listener)
		{
			_listeners.Add (listener);
		}

		public void StopListening(ISignalListenerGeneric<T> listener)
		{
			_listeners.Remove (listener);
		}
	}
}