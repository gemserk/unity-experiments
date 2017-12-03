using UnityEngine;
using Gemserk.Signals;
using Gemserk;

public class DelegatedSignalTestBehaviour : MonoBehaviour
{
	public InterfaceReference signal1;

	MethodSignalListener _methodSignalListener;

//	public UnityEvent myEvent;

	#region SignalHandler implementation

	public void MyCustomMethod (object t)
	{
		Debug.Log (string.Format("{0} - method signal listener, object: {1}", gameObject.name, t));
	}

//	public void MethodWithObject(Object o)
//	{
//	
//	}

	#endregion

	void Awake()
	{
		_methodSignalListener = new MethodSignalListener (signal1.Get<ISignalChannel>(), MyCustomMethod);
	}

	void OnEnable()
	{
		_methodSignalListener.StartListening ();
//		var signalChannel = signal1.Get<ISignalChannel> ();
//		if (signalChannel != null)
//			signalChannel.StartListening(_mySignalListener);
	}

	void OnDisable()
	{
		_methodSignalListener.StopListening ();
//		var signalChannel = signal1.Get<ISignalChannel> ();
//		if (signalChannel != null)
//			signalChannel.StopListening(_mySignalListener);
	}

}