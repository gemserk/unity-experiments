using UnityEngine;
using System;
using System.Collections.Generic;

namespace Gemserk.Values {

	public enum ValueDefinitionType {
//		Constant,
		Variable
	}

	// property drawer to select the inner value: int, float, string

	[Serializable]
	public class ValueDefinition {

		public string name;

//		public ValueDefinitionType type = ValueDefinitionType.Variable;

		public float number;

//		public float f;
//		public string s;

	}

	public class ValueContainerBehaviour : MonoBehaviour, ValueContainer {

//		public ValueDefinition valueDefinitionTest;

		public List<ValueDefinition> values = new List<ValueDefinition>();

		// ValueContainerDictionary _valueContainer = new ValueContainerDictionary();

		// TODO: use value container and custom property drawer to show value definitions.... if changed,
		// then change container values too..

		#region ValueContainer implementation

		public Value Get (string key)
		{
			ValueDefinition valueDefinition = null;

			foreach (var v in values) {
				if (v.name.Equals (key)) {
					valueDefinition = v;
					break;
				}
			}

			if (valueDefinition != null) {

				return new VariableValue (valueDefinition.number);

//				if (valueDefinition.type == ValueDefinitionType.Constant) {
//					return new ConstantValue ();
//				} else if (valueDefinition.type == ValueDefinitionType.Variable) {
//					return new VariableValue ();
//				}
			}

			return null;
//			return _valueContainer.Get (key);
		}

		#endregion

		// Use this for initialization
		void Awake () {
			// adds all its values to the container
//			foreach (var v in values) {
//				if (v.type == ValueDefinitionType.Constant) {
//					_valueContainer.Add (v.name, new ConstantValue ());
//				} else if (v.type == ValueDefinitionType.Variable) {
//					_valueContainer.Add (v.name, new VariableValue ());
//				}
//			}
		}

	}

}