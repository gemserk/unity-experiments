using UnityEngine;

namespace Gemserk.Signals
{
	[CreateAssetMenu(menuName="Signals/Signal Channel")]
	public class SignalChannelAsset : ScriptableObject, ISignalChannel
	{
		ISignalChannel _delegate;

		void OnEnable()
		{		
			_delegate = new SignalChannel ();
		}

		public void Signal(object signal)
		{
			_delegate.Signal (signal);
		}

		public void StartListening(ISignalListener listener)
		{
			_delegate.StartListening (listener);
		}

		public void StopListening(ISignalListener listener)
		{
			_delegate.StopListening (listener);
		}

	}

}