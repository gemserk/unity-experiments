
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
