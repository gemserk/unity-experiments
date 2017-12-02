
public interface ISignalChannel
{
	void Trigger(object signal);

	void Register(SignalHandler handler);

	void Unregister(SignalHandler handler);

}