using UnityEngine;
using System;
using System.Collections.Generic;

namespace Gemserk.Values {

//	public enum ValueDefinitionType {
//		Constant,
//		Variable
//		Number,
//		Object
//	}

	// property drawer to select the inner value: int, float, string

	public class ValueContainerBehaviour : MonoBehaviour, ValueContainer {

		[Serializable]
		public class ValueDefinitionEntry
		{
			public string name;
			public ValueDefinition value;
		}

		public List<ValueDefinitionEntry> values = new List<ValueDefinitionEntry>();

		// ValueContainerDictionary _valueContainer = new ValueContainerDictionary();

		// TODO: use value container and custom property drawer to show value definitions.... if changed,
		// then change container values too..

		#region ValueContainer implementation

		public Value Get (string key)
		{
			foreach (var v in values) {
				if (v.name.Equals (key)) {
					return v.value;
				}
			}

			return null;
		}

		#endregion

		// TODO: cache values?
	}

}