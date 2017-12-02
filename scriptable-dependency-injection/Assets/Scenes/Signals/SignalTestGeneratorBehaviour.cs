using UnityEngine;
using Gemserk.Injector;
using Gemserk.Signals;

public class SignalTestGeneratorBehaviour : MonoBehaviour {

	public InterfaceReference signal;

	public KeyCode testKey = KeyCode.Alpha1;
	public float health;

	void Update()
	{
		if (Input.GetKeyUp (testKey)) {
			signal.Get<ISignalChannel>().Signal (new Health () { 
				unit = this.gameObject,
				current = health
			});
		}
	}

}
