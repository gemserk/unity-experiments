using UnityEngine;
using Gemserk.Values;
using System.Collections.Generic;

[CreateAssetMenu(menuName="Gemserk/Values Container")]
public class TestContainerAsset : ScriptableObject, ValueContainer {

	public ValueContainerUnity valueContainer;

	#region ValueContainer implementation

	public List<string> GetKeys ()
	{
		return valueContainer.GetKeys ();
	}

	public Value Get (string key)
	{
		return valueContainer.Get (key);
	}

	public string Name {
		get {
			return valueContainer.name;
		}
	}

	#endregion


}
