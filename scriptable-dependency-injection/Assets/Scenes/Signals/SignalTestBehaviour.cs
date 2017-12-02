using UnityEngine;
using Gemserk.Injector;

public class SignalTestBehaviour : MonoBehaviour, SignalHandler {

	public InterfaceReference signal;

	#region SignalHandler implementation

	public void OnSignal (object t)
	{
		Health h = t as Health;
		if (h != null) {
			Debug.Log (h.current);
		}
	}

	#endregion

	void OnEnable()
	{
		signal.Get<ISignalChannel> ().Register (this);
	}

	void OnDisable()
	{
		signal.Get<ISignalChannel> ().Unregister (this);
	}
	
}
