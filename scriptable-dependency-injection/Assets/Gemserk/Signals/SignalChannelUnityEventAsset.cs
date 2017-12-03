using UnityEngine;
using UnityEngine.Events;

namespace Gemserk.Signals
{
	[CreateAssetMenu(menuName="Example1/Unity Event Channel")]
	public class SignalChannelUnityEventAsset : ScriptableObject, ISignalChannel
	{
		class UnityEventSignal : UnityEvent<object>
		{

		}

		UnityEventSignal _event;

		void OnEnable()
		{
			_event = new UnityEventSignal ();
		}

		#region ISignalChannel implementation
		public void Signal (object signal)
		{
			_event.Invoke (signal);
		}

		public void StartListening (ISignalListenerGeneric<object> listener)
		{
			_event.AddListener (listener.OnSignal);
		}

		public void StopListening (ISignalListenerGeneric<object> listener)
		{
			_event.RemoveListener(listener.OnSignal);
		}
		#endregion

	}

}