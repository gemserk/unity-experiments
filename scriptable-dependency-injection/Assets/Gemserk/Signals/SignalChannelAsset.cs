using UnityEngine;

[CreateAssetMenu(menuName="Signals/Signal Channel")]
public class SignalChannelAsset : ScriptableObject, ISignalChannel
{
	// this is just a delegate, to be able to reuse signal logic in other implementations

	ISignalChannel _delegate;

	void OnEnable()
	{		
		_delegate = new SignalChannel ();
	}

	public void Trigger(object signal)
	{
		_delegate.Trigger (signal);
	}

	public void Register(SignalListener listener)
	{
		_delegate.Register (listener);
	}

	public void Unregister(SignalListener listener)
	{
		_delegate.Unregister (listener);
	}
		
}
	