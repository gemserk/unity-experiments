using UnityEngine;
using Gemserk.Injector;
using UnityEngine.Serialization;
using Gemserk.Signals;

public class SignalTestBehaviour : MonoBehaviour, ISignalListener {

	[FormerlySerializedAsAttribute("signal")]
	public InterfaceReference signalChannel;

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
		if (signalChannel.Get<ISignalChannel>() != null)
			signalChannel.Get<ISignalChannel> ().StartListening (this);
	}

	void OnDisable()
	{
		if (signalChannel.Get<ISignalChannel>() != null)
			signalChannel.Get<ISignalChannel> ().StopListening (this);
	}
	
}

