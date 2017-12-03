using UnityEngine;
using Gemserk.Signals;
using Gemserk;

public class Example2SignalGenerator : MonoBehaviour {

	public InterfaceReference signal;

	public KeyCode testKey = KeyCode.Alpha1;

	void Update()
	{
		if (Input.GetKeyUp (testKey)) {
			signal.Get<ISignalChannel>().Signal (this.gameObject);
		}
	}
}
