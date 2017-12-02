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

		public void Register(ISignalListener listener)
		{
			_delegate.Register (listener);
		}

		public void Unregister(ISignalListener listener)
		{
			_delegate.Unregister (listener);
		}

	}

}