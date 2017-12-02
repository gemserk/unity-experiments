using UnityEngine;

public class SignalChannelBehaviour : MonoBehaviour, ISignalChannel
{
	// this is just a delegate, to be able to reuse signal logic in other implementations

	readonly SignalChannel _signalChannel = new SignalChannel();

	public void Trigger(object signal)
	{
		_signalChannel.Trigger (signal);
	}

	public void Register(SignalHandler handler)
	{
		_signalChannel.Register (handler);
	}

	public void Unregister(SignalHandler handler)
	{
		_signalChannel.Unregister (handler);
	}

}
