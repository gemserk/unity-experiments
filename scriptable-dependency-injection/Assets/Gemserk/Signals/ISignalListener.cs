
namespace Gemserk.Signals
{
	public interface ISignalListenerGeneric<T> where T : class
	{
		void OnSignal(T t);

		// startListening(channel)

		// stopListening(channel)
	}

	public interface ISignalListener : ISignalListenerGeneric<object>
	{
		
	}
}