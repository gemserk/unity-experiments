using UnityEngine;

namespace Gemserk.Signals
{
	public class SignalChannelBehaviour : MonoBehaviour, ISignalChannel
	{
		readonly ISignalChannel _delegate = new SignalChannel();

		public void Signal(object signal)
		{
			_delegate.Signal (signal);
		}

		public void StartListening(ISignalListener handler)
		{
			_delegate.StartListening (handler);
		}

		public void StopListening(ISignalListener handler)
		{
			_delegate.StopListening (handler);
		}

	}

}