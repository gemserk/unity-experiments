using System.Collections;
using UnityEngine;
using Gemserk.Signals;

public class GameModeController : MonoBehaviour {

	public Example1SignalChannel gameStartedChannel;
	public Example1SignalChannel gameOverChannel;
	public Example1SignalChannel charactedDiedChannel;

	MethodSignalListener _charactedDiedListener;

	public Transform startPosition;

	public GameObject mainCharacterPrefab;

	GameObject _mainCharacter;

	void Start () {
		_charactedDiedListener = new MethodSignalListener (charactedDiedChannel.Get(), OnCharacterDied);
		Restart ();
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
