using UnityEngine;
using Gemserk.Values;

public class TestSetValueBehaviour : MonoBehaviour {

	public Gemserk.Values.UnityContainerValue value;

	public int number;

	public ValueDefinition definition;

	void Start()
	{
		value.SetFloat(number);
	}


	// La value definition podría no tener que especificar el nombre

	// La lista tiene nombre + value definition

	// Tengo que poder usar la value definition fuera de una lista (contenedor)
}