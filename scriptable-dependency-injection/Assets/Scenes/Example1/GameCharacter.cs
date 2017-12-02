using UnityEngine;
using Gemserk.Injector;
using Gemserk.Signals;

public class GameCharacter : MonoBehaviour
{
	public InterfaceReference charactedDiedChannel;
	ISignalChannel _characterDiedChannel;

	bool _isDead;

	public KeyCode killKey = KeyCode.Alpha1;

	void Start () {
		_characterDiedChannel = charactedDiedChannel.Get<ISignalChannel> ();
	}

	void Update()
	{
		if (_isDead)
			return;
		
		if (Input.GetKeyUp(killKey)) {
			_isDead = true;
			_characterDiedChannel.Signal (this.gameObject);
		}
	}
}
