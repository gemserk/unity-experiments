using System.Collections;
using UnityEngine;
using Gemserk.Signals;
using System;
using Gemserk;

[SerializableAttribute]
public class SignalChannelCallbackBinding
{
	[SerializeField]
	protected InterfaceReference _channel;

	CallbackSignalListener<object> _callback;

	public ISignalChannel<object> GetChannel()
	{
		return _channel.Get<ISignalChannel<object>> ();
	}

	public void StartListening(Action<object> callback)
	{
		StopListening ();

		if (callback == null)
			return;

		_callback = new CallbackSignalListener<object> (_channel.Get<ISignalChannel<object>>(), callback);
		_callback.StartListening ();
	}

	public void StopListening()
	{
		if (_callback != null) {
			_callback.StopListening ();
			_callback = null;
		}
	}
}

public class GameModeController : MonoBehaviour {

	public Example1SignalChannel gameStartedChannel;
	public Example1SignalChannel gameOverChannel;

	[SerializeField]
	protected SignalChannelCallbackBinding _characterDiedChannel;

	public Example1SignalChannelHealthReference characterLoseHealthChannel;

//	CallbackSignalListener<object> _charactedDiedListener;
	CallbackSignalListener<Health> _characterLoseHealthListener;

	public Transform startPosition;

	public GameObject mainCharacterPrefab;

	GameObject _mainCharacter;

	void Start () {
//		_charactedDiedListener = new CallbackSignalListener<object> (charactedDiedChannel.Get(), OnCharacterDied);
		_characterDiedChannel.StartListening (OnCharacterDied);
		_characterLoseHealthListener = new CallbackSignalListener<Health> (characterLoseHealthChannel.Get(), OnCharacterLoseHealth);
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

	void OnCharacterLoseHealth(Health health)
	{
		Debug.Log(string.Format("Character {0} has {1} health", health.unit.name, health.current));

		health.current += 30;
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
