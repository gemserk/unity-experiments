using UnityEngine;

public class GameCharacter : MonoBehaviour
{
	public Example1SignalChannel charactedDiedChannel;

	bool _isDead;

	public KeyCode killKey = KeyCode.Alpha1;

	void Update()
	{
		if (_isDead)
			return;
		
		if (Input.GetKeyUp(killKey)) {
			_isDead = true;
			charactedDiedChannel.Get().Signal (this.gameObject);
		}
	}
}
