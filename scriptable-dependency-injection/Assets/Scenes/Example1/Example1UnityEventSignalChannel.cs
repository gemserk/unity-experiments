using UnityEngine;
using Gemserk.Signals;
using UnityEngine.Events;

[CreateAssetMenu(menuName="Example1/Unity Event Channel")]
public class Example1UnityEventSignalChannel : ScriptableObject, ISignalChannel
{
	class UnityEventSignal : UnityEvent<object>
	{

	}

	UnityEventSignal _event;

	void OnEnable()
	{
		_event = new UnityEventSignal ();
	}

	#region ISignalChannel implementation
	public void Signal (object signal)
	{
		_event.Invoke (signal);
	}

	public void StartListening (ISignalListener listener)
	{
		_event.AddListener (listener.OnSignal);
	}

	public void StopListening (ISignalListener listener)
	{
		_event.RemoveListener(listener.OnSignal);
	}
	#endregion
	
}
