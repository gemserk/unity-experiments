using UnityEngine;
using Gemserk.Signals;

public class Example1DebugChannel : MonoBehaviour, ISignalListener
{
	public Example1SignalChannel channel;

	public string message;

	void OnEnable()
	{
		channel.Get ().StartListening (this);
	}

	void OnDisable()
	{
		channel.Get ().StopListening (this);
	}

	#region ISignalListener implementation
	public void OnSignal (object t)
	{
		Debug.Log (message);
	}
	#endregion
}
