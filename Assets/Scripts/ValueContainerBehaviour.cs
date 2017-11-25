using System;
using System.Linq;
using System.Collections.Generic;

namespace Gemserk.Values {

	public class ValueContainerBehaviour : ValueContainerBase {

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

		public override List<string> GetKeys ()
		{
			return values.Select (v => v.name).ToList ();
		}

		public override Value Get (string key)
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

	// Editable en runtime desde editor

	// Fácil de referenciar valores de otras clases

	// Fácil de leer en editor

	// Tener un contenedor por defecto si no hay ninguno especificado?

	// Fácil de configurar usar una variable, no quiero tener que seleccionar el contenedor cada vez
	// Contenedor global de variables por defecto. GLOBAL / LOCAL

	// pasar a github

	// el value consumer podría directamente listar toda la lista de variables en todo el sistema
	// el tema es manejar bien el contenedor/indice y que el editor sea eficiente.
	// - soportar rename de un contenedor sin problemas
	// - el global pierde sentido, todos pasan a ser global
	// - test: dos contenedores se llaman igual

	// en el consumer no se los nombres de variable local

}