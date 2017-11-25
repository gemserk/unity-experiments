using UnityEngine;
using Gemserk.Values;

public class TestSetValueBehaviour : MonoBehaviour {

	public Gemserk.Values.UnityContainerValue value;

	public ValueDefinition definition;

	[InspectorButtonAttribute("OnConfigureValue")]
	public bool setValue;

	public void OnConfigureValue()
	{
		definition.Override (value);
//		value.SetFloat(definition.GetFloat());
	}
		
	// Tengo que poder usar la value definition fuera de una lista (contenedor)
}