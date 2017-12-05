using System.Collections;
using UnityEngine;
using Gemserk.Signals;

public class GameModeController : MonoBehaviour {

	public Example1SignalChannel gameStartedChannel;
	public Example1SignalChannel gameOverChannel;
	public Example1SignalChannel charactedDiedChannel;

	public Example1SignalChannelHealthReference characterLoseHealthChannel;

	CallbackSignalListener<object> _charactedDiedListener;

	CallbackSignalListener<Health> _characterLoseHealthListener;

	public Transform startPosition;

	public GameObject mainCharacterPrefab;

	GameObject _mainCharacter;

//	Example1Event pipote = new Example1Event();

//	public void PipoteCall(object obj)
//	{
//		
//	}

	void Start () {
		_charactedDiedListener = new CallbackSignalListener<object> (charactedDiedChannel.Get(), OnCharacterDied);
		_characterLoseHealthListener = new CallbackSignalListener<Health> (characterLoseHealthChannel.Get(), OnCharacterLoseHealth);
		Restart ();

//		pipote = new Example1Event ();

//		pipote.AddListener (delegate(object arg0) {
//			Debug.Log((arg0 as GameObject).name);
//		});
//
//		pipote.Invoke (this.gameObject);
	}

	void Restart()
	{
		if (_mainCharacter != null) {
			GameObject.Destroy (_mainCharacter);
			_mainCharacter = null;
		}

		_mainCharacter = GameObject.Instantiate(mainCharacterPrefab);
		_mainCharacter.transform.position = startPosition.position;

		gameStartedChannel.Get().Signal (this);
	}

	void OnCharacterLoseHealth(Health health)
	{
		Debug.Log(string.Format("Character {0} has {1} health", health.unit.name, health.current));
	}

	void OnCharacterDied (object character)
	{
		if (character != _mainCharacter)
			return;
		
		StartCoroutine(GameOver());
	}

	IEnumerator GameOver()
	{
		if (_mainCharacter != null) {
			GameObject.Destroy (_mainCharacter);
			_mainCharacter = null;
		}

		yield return new WaitForSeconds (1.0f);

		// do stuff

		gameOverChannel.Get().Signal (this);

		yield return new WaitForSeconds (1.0f);
	
		Restart ();
	}
		
}
