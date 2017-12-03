using Gemserk.Signals;
using UnityEngine;

[CreateAssetMenu(menuName="Example1/Health Signal")]
public class Example1SignalChannelHealth : ScriptableObject, ISignalChannel<Health>
{
	readonly SignalChannel<Health> _delegate = new SignalChannel<Health>();

	#region ISignalChannelGeneric implementation
	public void Signal (Health signal)
	{
		_delegate.Signal (signal);
	}

	public void StartListening (ISignalListener<Health> listener)
	{
		_delegate.StartListening (listener);
	}

	public void StopListening (ISignalListener<Health> listener)
	{
		_delegate.StopListening (listener);
	}

	#endregion
	
}