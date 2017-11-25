using UnityEngine;
using Gemserk.Values;
using System.Collections.Generic;
using System.Linq;

[CreateAssetMenu(menuName="Gemserk/Values Container")]
public class TestContainerAsset : ScriptableObject, ValueContainer {

	public List<ValueContainerBehaviour.ValueDefinitionEntry> values = new List<ValueContainerBehaviour.ValueDefinitionEntry>();

	#region ValueContainer implementation

	public List<string> GetKeys ()
	{
		return values.Select (v => v.name).ToList ();
	}

	public Value Get (string key)
	{
		foreach (var v in values) {
			if (v.name.Equals (key)) {
				return v.value;
			}
		}

		return null;
	}
	public string Name {
		get {
			return this.name;
		}
	}

	#endregion


}
