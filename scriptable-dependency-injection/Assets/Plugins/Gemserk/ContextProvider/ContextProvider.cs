
public interface ContextProvider
{
	T Get<T>() where T : class;
}
