using UnityEngine;

public class SignalChannelBehaviour : MonoBehaviour, ISignalChannel
{
	// this is just a delegate, to be able to reuse signal logic in other implementations

	readonly ISignalChannel _delegate = new SignalChannel();

	public void Trigger(object signal)
	{
		_delegate.Trigger (signal);
	}

	public void Register(SignalListener handler)
	{
		_delegate.Register (handler);
	}

	public void Unregister(SignalListener handler)
	{
		_delegate.Unregister (handler);
	}

}
