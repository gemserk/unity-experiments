
namespace Gemserk.Signals
{
	public interface ISignalChannel
	{
		void Signal(object signal);

		void StartListening(ISignalListener listener);

		void StopListening(ISignalListener listener);
	}
}