using UnityEngine;
using System.Collections.Generic;
using System;

public abstract class SignalBase<T> : ScriptableObject where T : class
{
	[NonSerializedAttribute]
	readonly List<SignalHandler<T>> _handlers = new List<SignalHandler<T>>();

	void OnDisable()
	{
		_handlers.Clear ();
	}

	public void Trigger(T t)
	{
		foreach (var handler in _handlers) {
			handler.OnSignal (t);
		}
	}

	public void Register(SignalHandler<T> handler)
	{
		_handlers.Add (handler);
	}

	public void Unregister(SignalHandler<T> handler)
	{
		_handlers.Remove (handler);
	}
		
}
