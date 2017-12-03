
namespace Gemserk.Signals
{
	public interface ISignalChannelGeneric<T> where T : class
	{
		void Signal(T signal);

		void StartListening(ISignalListenerGeneric<T> listener);

		void StopListening(ISignalListenerGeneric<T> listener);
	}

	public interface ISignalChannel : ISignalChannelGeneric<object>
	{

	}
}