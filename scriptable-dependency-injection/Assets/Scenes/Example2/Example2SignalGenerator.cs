using UnityEngine;
using Gemserk.Signals;
using Gemserk;

public class Example2SignalGenerator : MonoBehaviour {

	public SignalChannelReference signal;

	public KeyCode testKey = KeyCode.Alpha1;

	void Update()
	{
		if (Input.GetKeyUp (testKey)) {
			signal.Get().Signal (this.gameObject);
		}
	}
}
