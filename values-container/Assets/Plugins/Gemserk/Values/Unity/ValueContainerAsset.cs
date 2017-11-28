using UnityEngine;
using Gemserk.Values;
using System.Collections.Generic;

[CreateAssetMenu(menuName="Gemserk/Values Container")]
public class ValueContainerAsset : ScriptableObject, ValueContainerUnityObject {

	public ValueContainerUnity valueContainer;

	public string optionalName;

	public string Name {
		get {
			if (!string.IsNullOrEmpty (optionalName))
				return optionalName;
			return name;
		}
	}

	public ValueContainer ValueContainer {
		get {
			return valueContainer;
		}
	}

	#region ValueContainer implementation

	public List<string> GetKeys ()
	{
		return valueContainer.GetKeys ();
	}

	public Value Get (string key)
	{
		return valueContainer.Get (key);
	}
		
	#endregion


}
