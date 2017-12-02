using System.Collections;
using UnityEngine;
using Gemserk.Injector;
using Gemserk.Signals;
using System;

public class GameModeController : MonoBehaviour {

	public InterfaceReference gameStartedChannel;
	public InterfaceReference gameOverChannel;
	public InterfaceReference charactedDiedChannel;

	ISignalChannel _gameStartedChannel;
	ISignalChannel _gameOverChannel;
	ISignalChannel _characterDiedChannel;

	MethodSignalListener _charactedDiedListener;

	public Transform startPosition;

	public GameObject mainCharacterPrefab;

	GameObject _mainCharacter;

	void Start () {
		_gameStartedChannel = gameStartedChannel.Get<ISignalChannel> ();
		_gameOverChannel = gameOverChannel.Get<ISignalChannel> ();
		_characterDiedChannel = charactedDiedChannel.Get<ISignalChannel> ();

		_charactedDiedListener = new MethodSignalListener (_characterDiedChannel, OnCharacterDied);
		_charactedDiedListener.StartListening ();
	
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

		_gameStartedChannel.Signal (this);
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

		_gameOverChannel.Signal (this);

		yield return new WaitForSeconds (1.0f);
	
		Restart ();
	}
		
}
