using UnityEngine;
using System.Collections.Generic;
using System;

public interface SignalHandler<T>
{
	void OnSignal(T t);
}
