using UnityEngine;

namespace Gemserk.Signals
{
	public class SignalChannelAssetGeneric<T> : ScriptableObject, ISignalChannel<T> where T : class
	{
		ISignalChannel<T> _delegate;

		void OnEnable()
		{		
			_delegate = new SignalChannel<T> ();
		}

		public void Signal(T signal)
		{
			_delegate.Signal (signal);
		}

		public void StartListening (ISignalListener<T> listener)
		{
			_delegate.StartListening (listener);
		}

		public void StopListening (ISignalListener<T> listener)
		{
			_delegate.StopListening (listener);
		}
	}

}