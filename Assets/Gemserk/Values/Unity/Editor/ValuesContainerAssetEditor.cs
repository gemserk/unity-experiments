using UnityEditor;
using Gemserk.Values;

[CustomEditor(typeof(ValuesContainerAsset), true)]
public class ValuesContainerAssetEditor : ValueContainerEditorBase {

	public override void AddNewElement()
	{
		ValuesContainerAsset container = (ValuesContainerAsset) target;
		container.valueContainer.values.Add (new ValueContainerUnity.ValueDefinitionEntry ());
	}

	public override void RemoveElement (int index)
	{
		ValuesContainerAsset container = (ValuesContainerAsset) target;
		container.valueContainer.values.RemoveAt (index);
	}

}