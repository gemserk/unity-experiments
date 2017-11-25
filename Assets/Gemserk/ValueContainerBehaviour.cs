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

	[Serializable]
	public class ValueDefinition {

		public string name;

//		public ValueDefinitionType type = ValueDefinitionType.Variable;

		// used by editor
		public int type;

		public float number;
		public UnityEngine.Object reference;

		public Value GetValue()
		{
			return new VariableValue (number, reference);
		}
	}

	public class ValueContainerBehaviour : MonoBehaviour, ValueContainer {

		public List<ValueDefinition> values = new List<ValueDefinition>();

		// ValueContainerDictionary _valueContainer = new ValueContainerDictionary();

		// TODO: use value container and custom property drawer to show value definitions.... if changed,
		// then change container values too..

		#region ValueContainer implementation

		public Value Get (string key)
		{
			foreach (var v in values) {
				if (v.name.Equals (key)) {
					return v.GetValue ();
				}
			}

			return null;
		}

		#endregion

		// TODO: cache values?
	}

}