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

		public void Register(ISignalListener handler)
		{
			_delegate.Register (handler);
		}

		public void Unregister(ISignalListener handler)
		{
			_delegate.Unregister (handler);
		}

	}

}