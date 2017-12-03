using UnityEngine;

namespace Gemserk.Signals
{
	[CreateAssetMenu(menuName="Signals/Signal Channel")]
	public class SignalChannelAsset : ScriptableObject, ISignalChannel
	{
		ISignalChannelGeneric<object> _delegate;

		void OnEnable()
		{		
			_delegate = new SignalChannel<object> ();
		}

		public void Signal(object signal)
		{
			_delegate.Signal (signal);
		}
			
		public void StartListening (ISignalListenerGeneric<object> listener)
		{
			_delegate.StartListening (listener);
		}

		public void StopListening (ISignalListenerGeneric<object> listener)
		{
			_delegate.StopListening (listener);
		}
	}

}