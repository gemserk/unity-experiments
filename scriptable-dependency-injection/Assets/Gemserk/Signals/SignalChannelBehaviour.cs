using UnityEngine;

namespace Gemserk.Signals
{
	public class SignalChannelBehaviour : MonoBehaviour, ISignalChannel
	{
		readonly ISignalChannelGeneric<object> _delegate = new SignalChannel<object>();

		public void Signal(object signal)
		{
			_delegate.Signal (signal);
		}

		public void StartListening(ISignalListenerGeneric<object> handler)
		{
			_delegate.StartListening (handler);
		}

		public void StopListening(ISignalListenerGeneric<object> handler)
		{
			_delegate.StopListening (handler);
		}

	}

}