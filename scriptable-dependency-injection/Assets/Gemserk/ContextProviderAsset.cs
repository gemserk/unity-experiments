using UnityEngine;

public interface ContextProvider
{
	T Get<T>() where T : class;
}

public class ContextProviderImpl : ContextProvider
{
	object _instance;

	public void Set<T>(T instance) where T : class
	{
		_instance = instance;
	}

	#region ContextProvider implementation
	public T Get<T> () where T : class
	{
		return _instance as T;
	}

	#endregion
}

[CreateAssetMenu(menuName="Gemserk/Context Provider")]
public class ContextProviderAsset : ScriptableObject, ContextProvider {

	ContextProviderImpl _delegate = new ContextProviderImpl();

	public void Set<T>(T instance) where T : class
	{
		_delegate.Set<T> (instance);
	}

	#region ContextProvider implementation
	public T Get<T> () where T : class
	{
		return _delegate.Get<T> ();
	}

	#endregion

	void Awake()
	{
		Debug.Log ("Scriptable.Awake " + Application.isPlaying);
	}

	void OnEnable()
	{
		Debug.Log ("Scriptable.OnEnable " + Application.isPlaying);

	}

	void OnDisable()
	{
		Debug.Log ("Scriptable.OnDisable "+ Application.isPlaying);

	}

	void OnDestroy()
	{
		Debug.Log ("Scriptable.OnDestroy" + Application.isPlaying);

	}
	
}
