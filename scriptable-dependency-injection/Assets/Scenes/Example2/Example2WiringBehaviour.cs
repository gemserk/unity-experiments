using UnityEngine;
using Gemserk.Signals;
using UnityEngine.Events;
using System;
using Gemserk;

public class Example2WiringBehaviour : MonoBehaviour, ISignalListener<object> {

	[SerializableAttribute]
	public class UnityEventObject : UnityEvent<UnityEngine.Object>
	{
		
	}

	public SignalChannelReference signal;

	public UnityEventObject wiredMethods;

	#region ISignalListener implementation

	public void OnSignal (object t)
	{
		wiredMethods.Invoke (t as UnityEngine.Object);
	}

	#endregion

	// Use this for initialization
	void Start () {
		signal.Get().StartListening (this);
	}

}
