
public interface ISignalChannel
{
	void Trigger(object signal);

	void Register(SignalListener listener);

	void Unregister(SignalListener listener);

}