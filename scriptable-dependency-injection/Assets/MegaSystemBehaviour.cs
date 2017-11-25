using UnityEngine;

public class MegaSystemBehaviour : MonoBehaviour, IMegaSystem {

	public string superValue;

	#region IMegaSystem implementation
	public string GetSuperValue ()
	{
		return superValue;
	}
	#endregion
	
}
