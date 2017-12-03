using UnityEngine;

public class Example2SignalGenerator : MonoBehaviour {

	public Example1SignalChannelHealthReference signal;

	public KeyCode testKey = KeyCode.Alpha1;

	void Update()
	{
		if (Input.GetKeyUp (testKey)) {
			signal.Get().Signal (new Health() {
				current = 50,
				unit = this.gameObject
			});
		}
	}
}
