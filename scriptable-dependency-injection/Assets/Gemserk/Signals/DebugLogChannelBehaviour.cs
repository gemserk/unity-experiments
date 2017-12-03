using UnityEngine;
using Gemserk.Signals;
using Gemserk.Injector;

public class DebugLogChannelBehaviour : MonoBehaviour, ISignalListener
{
	public InterfaceReference channel;

	public string message;

	void OnEnable()
	{
		channel.Get<ISignalChannel>().StartListening (this);
	}

	void OnDisable()
	{
		channel.Get<ISignalChannel>().StopListening (this);
	}

	#region ISignalListener implementation

	public void OnSignal (object t)
	{
		Debug.LogFormat(message, t);
	}

	#endregion
}
