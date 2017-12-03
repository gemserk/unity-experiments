using UnityEngine;

namespace Gemserk.Signals
{
	// TODO: extract generic base class and implement one with object type
	
	public class SignalChannelBehaviour : MonoBehaviour, ISignalChannel<object>
	{
		readonly ISignalChannel<object> _delegate = new SignalChannel<object>();

		public void Signal(object signal)
		{
			_delegate.Signal (signal);
		}

		public void StartListening(ISignalListener<object> handler)
		{
			_delegate.StartListening (handler);
		}

		public void StopListening(ISignalListener<object> handler)
		{
			_delegate.StopListening (handler);
		}

	}

}