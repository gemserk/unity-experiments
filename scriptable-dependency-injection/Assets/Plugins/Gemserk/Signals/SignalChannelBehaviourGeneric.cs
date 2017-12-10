using UnityEngine;

namespace Gemserk.Signals
{
	public class SignalChannelBehaviourGeneric<T> : MonoBehaviour, ISignalChannel<T> where T : class
	{
		readonly ISignalChannel<T> _delegate = new SignalChannel<T>();

		public void Signal(T signal)
		{
			_delegate.Signal (signal);
		}

		public void StartListening(ISignalListener<T> handler)
		{
			_delegate.StartListening (handler);
		}

		public void StopListening(ISignalListener<T> handler)
		{
			_delegate.StopListening (handler);
		}

	}

}