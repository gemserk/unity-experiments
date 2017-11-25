using UnityEditor;
using Gemserk.Values;

[CustomEditor(typeof(ValueContainerBehaviour), true)]
public class ValueContainerBehaviourEditor : ValueContainerEditor {

	public override void AddNewElement()
	{
		ValueContainerBehaviour container = (ValueContainerBehaviour) target;
		container.valueContainer.values.Add (new ValueContainerUnity.ValueDefinitionEntry ());
	}

	public override void RemoveElement (int index)
	{
		ValueContainerBehaviour container = (ValueContainerBehaviour) target;
		container.valueContainer.values.RemoveAt (index);
	}
}