
namespace Gemserk.Signals
{
	public interface ISignalChannel
	{
		void Signal(object signal);

		void Register(ISignalListener listener);

		void Unregister(ISignalListener listener);
	}
}