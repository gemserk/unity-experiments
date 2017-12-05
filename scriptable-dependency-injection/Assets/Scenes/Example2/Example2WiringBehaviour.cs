using UnityEngine;
using Gemserk.Signals;

public class Example2WiringBehaviour : MonoBehaviour, ISignalListener<Health> {

	public Example1SignalChannelHealthReference signal;

	public Example2UnityEventHealth wiredMethods;

	public UnityEventSignal otherMethod;

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
