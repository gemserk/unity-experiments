using UnityEngine;
using Gemserk.Injector;

public class SignalTestBehaviour : MonoBehaviour, SignalHandler {

	public InterfaceReference signal;

	public GameObject unit;

	#region SignalHandler implementation

	public void OnSignal (object t)
	{
		Health h = t as Health;

		if (h != null) {
			// if interested in one unit and health unit is not the one in interest, then do nothing.
			if (unit != null && h.unit != unit)
				return;
			Debug.Log (string.Format("{0} - health {2} received: {1}", gameObject.name, h.current, unit != null ? unit.name : "generic"));
		}
	}

	#endregion

	void OnEnable()
	{
		if (signal.Get<ISignalChannel>() != null)
			signal.Get<ISignalChannel> ().Register (this);
	}

	void OnDisable()
	{
		if (signal.Get<ISignalChannel>() != null)
			signal.Get<ISignalChannel> ().Unregister (this);
	}
	
}
