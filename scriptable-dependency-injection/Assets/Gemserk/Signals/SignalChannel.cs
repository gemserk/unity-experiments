using System.Collections.Generic;

public class SignalChannel: ISignalChannel
{
	readonly List<SignalHandler> _handlers = new List<SignalHandler>();

	void OnDisable()
	{
		_handlers.Clear ();
	}

	public void Trigger(object signal)
	{
		foreach (var handler in _handlers) {
			handler.OnSignal (signal);
		}
	}

	public void Register(SignalHandler handler)
	{
		_handlers.Add (handler);
	}

	public void Unregister(SignalHandler handler)
	{
		_handlers.Remove (handler);
	}
}