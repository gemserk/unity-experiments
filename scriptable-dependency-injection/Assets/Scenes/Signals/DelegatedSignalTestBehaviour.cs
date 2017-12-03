using UnityEngine;
using Gemserk.Signals;

public class DelegatedSignalTestBehaviour : MonoBehaviour
{
	public SignalChannelReference signal1;

	MethodSignalListener<object> _methodSignalListener;

	#region SignalHandler implementation

	public void MyCustomMethod (object t)
	{
		Debug.Log (string.Format("{0} - method signal listener, object: {1}", gameObject.name, t));
	}
	#endregion

	void Awake()
	{
		_methodSignalListener = new MethodSignalListener<object> (signal1.Get(), MyCustomMethod);
	}

	void OnEnable()
	{
		_methodSignalListener.StartListening ();
	}

	void OnDisable()
	{
		_methodSignalListener.StopListening ();
	}

}