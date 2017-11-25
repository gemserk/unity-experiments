using UnityEngine;
using System;
using System.Collections.Generic;

namespace Gemserk.Values {

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

	// Cambiar valores en editor deberían cambiar en memoria

	// Fácil de referenciar valores de otras clases

	// Fácil de leer en editor

	// Tener un contenedor por defecto si no hay ninguno especificado?

	// Fácil de configurar usar una variable, no quiero tener que seleccionar el contenedor cada vez
	// Contenedor global de variables por defecto. GLOBAL / LOCAL

	// Sin redundancia, para aumentar claridad

	// Undo!!

}