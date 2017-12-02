using UnityEngine;

public class SignalTestGeneratorBehaviour : MonoBehaviour {

	public SignalUnitDeath signal;

	void Update()
	{
		if (Input.GetKeyUp (KeyCode.Alpha1)) {
			signal.Trigger (new Health () { 
				current = 50
			});
		}
	}

}
