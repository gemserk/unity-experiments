using UnityEngine;
using Gemserk.Injector;
using Gemserk.Signals;

public class MultipleSignalsListenerTestBehaviour : MonoBehaviour, ISignalListener {

	// se puede encapsular lista de referencias a channels, para el register, etc..
	public InterfaceReference[] signalChannels;

//	public GameObject unit;

	#region SignalHandler implementation

	public void OnSignal (object t)
	{
//		Health h = t as Health;
//
//		if (h != null) {
//			// if interested in one unit and health unit is not the one in interest, then do nothing.
//			if (unit != null && h.unit != unit)
//				return;
//			Debug.Log (string.Format("{0} - health {2} received: {1}", gameObject.name, h.current, unit != null ? unit.name : "generic"));
//		}

		Debug.Log (string.Format("{0} - signal object: {1}", gameObject.name, t));
	}

	#endregion

	void OnEnable()
	{
		foreach (var signalChannel in signalChannels) {
			if (signalChannel.Get<ISignalChannel>() != null)
				signalChannel.Get<ISignalChannel> ().Register (this);			
		}
	}

	void OnDisable()
	{
		foreach (var signalChannel in signalChannels) {
			if (signalChannel.Get<ISignalChannel>() != null)
				signalChannel.Get<ISignalChannel> ().Unregister (this);			
		}
	}

}

