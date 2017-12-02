using UnityEngine;
using Gemserk.Injector;
using Gemserk.Signals;

public class DelegatedSignalTestBehaviour : MonoBehaviour
{
	public InterfaceReference signal1;

	MethodSignalListener _mySignalListener;

	#region SignalHandler implementation

	void MyCustomMethod (object t)
	{
		Debug.Log (string.Format("{0} - method signal listener, object: {1}", gameObject.name, t));
	}

	#endregion

	void Awake()
	{
		_mySignalListener = new MethodSignalListener (MyCustomMethod);
	}

	void OnEnable()
	{
		var signalChannel = signal1.Get<ISignalChannel> ();
		if (signalChannel != null)
			signalChannel.Register(_mySignalListener);
	}

	void OnDisable()
	{
		var signalChannel = signal1.Get<ISignalChannel> ();
		if (signalChannel != null)
			signalChannel.Unregister(_mySignalListener);
	}

}