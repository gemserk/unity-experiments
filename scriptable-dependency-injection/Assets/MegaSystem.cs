using UnityEngine;

[CreateAssetMenu(menuName="Custom/Mega System")]
public class MegaSystem : ScriptableObject, IMegaSystem
{
	public string superValue;

	#region IMegaSystem implementation

	public string GetSuperValue ()
	{
		return superValue;
	}

	#endregion
	
}
