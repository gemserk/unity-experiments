using System.Collections.Generic;

public class SignalChannel: ISignalChannel
{
	readonly List<SignalListener> _listeners = new List<SignalListener>();

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

	public void Register(SignalListener listener)
	{
		_listeners.Add (listener);
	}

	public void Unregister(SignalListener listener)
	{
		_listeners.Remove (listener);
	}
}