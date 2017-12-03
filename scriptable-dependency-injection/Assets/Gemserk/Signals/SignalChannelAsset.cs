using UnityEngine;

namespace Gemserk.Signals
{
	// TODO: extract generic to reimplement with custom type

	[CreateAssetMenu(menuName="Signals/Signal Channel")]
	public class SignalChannelAsset : ScriptableObject, ISignalChannel<object>
	{
		ISignalChannel<object> _delegate;

		void OnEnable()
		{		
			_delegate = new SignalChannel<object> ();
		}

		public void Signal(object signal)
		{
			_delegate.Signal (signal);
		}
			
		public void StartListening (ISignalListener<object> listener)
		{
			_delegate.StartListening (listener);
		}

		public void StopListening (ISignalListener<object> listener)
		{
			_delegate.StopListening (listener);
		}
	}

}