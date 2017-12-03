using UnityEngine;
using Gemserk.Signals;

public class DebugLogChannelBehaviour : MonoBehaviour, ISignalListener
{
	public SignalChannelReference channel;

	public string message;

	void OnEnable()
	{
		channel.Get().StartListening (this);
	}

	void OnDisable()
	{
		channel.Get().StopListening (this);
	}

	#region ISignalListener implementation

	public void OnSignal (object t)
	{
		Debug.LogFormat(message, t);
	}

	#endregion
}
