using UnityEngine;
using Gemserk.Signals;
using Gemserk;

public class SignalTestGeneratorBehaviour : MonoBehaviour {

	public SignalChannelReference signal;

	public KeyCode testKey = KeyCode.Alpha1;
	public float health;

	void Update()
	{
		if (Input.GetKeyUp (testKey)) {
			signal.Get().Signal (new Health () { 
				unit = this.gameObject,
				current = health
			});
		}
	}

}
