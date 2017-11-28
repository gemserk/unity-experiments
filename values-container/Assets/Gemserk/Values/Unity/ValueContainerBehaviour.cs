using System.Collections.Generic;
using UnityEngine;

namespace Gemserk.Values {

	public interface ValueContainerUnityObject : ValueContainer
	{
		string Name {
			get;
		}

		ValueContainer ValueContainer {
			get;
		}
	}

	public class ValueContainerBehaviour : MonoBehaviour, ValueContainerUnityObject {

		public ValueContainerUnity valueContainer;

		public string Name {
			get { 
				return gameObject.name;
			}
		}

		public ValueContainer ValueContainer {
			get { 
				return valueContainer;
			}
		}

		// ValueContainerDictionary _valueContainer = new ValueContainerDictionary();

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

		// TODO: cache values?

//		void OnValidate()
//		{
//			if (string.IsNullOrEmpty (valueContainer.name))
//				valueContainer.name = gameObject.name;
//		}

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