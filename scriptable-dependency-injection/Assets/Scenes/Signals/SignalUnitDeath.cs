using UnityEngine;

public class Health
{
	public float current;
}

[CreateAssetMenu(menuName="Signals/Health")]
public class SignalUnitDeath : SignalBase<Health> {
	
}

