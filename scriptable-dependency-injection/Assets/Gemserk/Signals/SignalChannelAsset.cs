using UnityEngine;

[CreateAssetMenu(menuName="Signals/Signal Channel")]
public class SignalChannelAsset : ScriptableObject, ISignalChannel
{
	// this is just a delegate, to be able to reuse signal logic in other implementations

	SignalChannel _signalChannel;

	void OnEnable()
	{		
		_signalChannel = new SignalChannel ();
	}

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
