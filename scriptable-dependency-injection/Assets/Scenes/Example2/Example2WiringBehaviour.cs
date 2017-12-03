using UnityEngine;
using Gemserk.Injector;
using Gemserk.Signals;
using UnityEngine.Events;
using System;

public class Example2WiringBehaviour : MonoBehaviour, ISignalListener {

	[SerializableAttribute]
	public class UnityEventObject : UnityEvent<UnityEngine.Object>
	{
		
	}

	public InterfaceReference signal;

	public UnityEventObject wiredMethods;

	#region ISignalListener implementation

	public void OnSignal (object t)
	{
		wiredMethods.Invoke (t as UnityEngine.Object);
	}

	#endregion

	// Use this for initialization
	void Start () {
		signal.Get<ISignalChannel> ().StartListening (this);
	}

}
