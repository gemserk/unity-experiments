
namespace Gemserk.Signals
{
	public interface ISignalChannel
	{
		void Trigger(object signal);

		void Register(ISignalListener listener);

		void Unregister(ISignalListener listener);

	}
}