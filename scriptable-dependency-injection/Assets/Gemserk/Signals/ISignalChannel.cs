
namespace Gemserk.Signals
{
	public interface ISignalChannel<T> where T : class
	{
		void Signal(T signal);

		void StartListening(ISignalListenerGeneric<T> listener);

		void StopListening(ISignalListenerGeneric<T> listener);
	}
}