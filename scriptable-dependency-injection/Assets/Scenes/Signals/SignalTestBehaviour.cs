using UnityEngine;
using UnityEngine.Serialization;
using Gemserk.Signals;

public class SignalTestBehaviour : MonoBehaviour, ISignalListener<object> {

	[FormerlySerializedAsAttribute("signal")]
	public SignalChannelReference signalChannel;

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
		if (signalChannel.Get() != null)
			signalChannel.Get().StartListening (this);
	}

	void OnDisable()
	{
		if (signalChannel.Get() != null)
			signalChannel.Get().StopListening (this);
	}
	
}

