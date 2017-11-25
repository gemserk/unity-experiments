using UnityEditor;
using Gemserk.Values;

[CustomEditor(typeof(ValueContainerAsset), true)]
public class ValueContainerAssetEditor : ValueContainerEditor {

	public override void AddNewElement()
	{
		ValueContainerAsset container = (ValueContainerAsset) target;
		container.valueContainer.values.Add (new ValueContainerUnity.ValueDefinitionEntry ());
	}

	public override void RemoveElement (int index)
	{
		ValueContainerAsset container = (ValueContainerAsset) target;
		container.valueContainer.values.RemoveAt (index);
	}

}