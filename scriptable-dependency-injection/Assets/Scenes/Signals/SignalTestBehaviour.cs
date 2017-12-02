using UnityEngine;

public class SignalTestBehaviour : MonoBehaviour, SignalHandler<Health> {

	public SignalUnitDeath signal;

	#region SignalHandler implementation

	public void OnSignal (Health t)
	{
		Debug.Log (t.current);
	}

	#endregion

	void OnEnable()
	{
		signal.Register (this);
	}

	void OnDisable()
	{
		signal.Unregister (this);
	}
	
}
