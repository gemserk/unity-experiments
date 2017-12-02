using UnityEngine;
using Gemserk.Injector;

public class SignalTestGeneratorBehaviour : MonoBehaviour {

	public InterfaceReference signal;

	void Update()
	{
		if (Input.GetKeyUp (KeyCode.Alpha1)) {
			signal.Get<ISignalChannel>().Trigger (new Health () { 
				current = 50
			});
		}
	}

}
