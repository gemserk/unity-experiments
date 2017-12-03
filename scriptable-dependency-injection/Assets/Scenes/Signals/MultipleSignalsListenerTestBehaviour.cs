using UnityEngine;
using Gemserk.Signals;

public class MultipleSignalsListenerTestBehaviour : MonoBehaviour, ISignalListener {

	public SignalChannelReference[] signalChannels;

	#region SignalHandler implementation

	public void OnSignal (object t)
	{
		Debug.Log (string.Format("{0} - signal object: {1}", gameObject.name, t));
	}

	#endregion

	void OnEnable()
	{
		foreach (var signalChannel in signalChannels) {
			if (signalChannel.Get() != null)
				signalChannel.Get().StartListening (this);			
		}
	}

	void OnDisable()
	{
		foreach (var signalChannel in signalChannels) {
			if (signalChannel.Get() != null)
				signalChannel.Get().StopListening (this);			
		}
	}

}

