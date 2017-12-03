using UnityEngine;
using Gemserk.Signals;
using UnityEngine.Events;
using System;
using Gemserk;

public class Example2WiringBehaviour : MonoBehaviour, ISignalListener<Health> {

	// test using custom object channel like health...

	[SerializableAttribute]
	public class UnityEventObject : UnityEvent<Health>
	{
		
	}

	public Example1SignalChannelHealthReference signal;

	public UnityEventObject wiredMethods;

	#region ISignalListener implementation

	public void OnSignal (Health t)
	{
		wiredMethods.Invoke (t);
	}

	#endregion

	// Use this for initialization
	void Start () {
		signal.Get().StartListening (this);
	}

}
