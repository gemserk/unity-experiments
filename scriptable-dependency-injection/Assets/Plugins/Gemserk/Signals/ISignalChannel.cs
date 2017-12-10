
namespace Gemserk.Signals
{
	public interface ISignalChannel<T> where T : class
	{
		void Signal(T signal);

		void StartListening(ISignalListener<T> listener);

		void StopListening(ISignalListener<T> listener);
	}
}