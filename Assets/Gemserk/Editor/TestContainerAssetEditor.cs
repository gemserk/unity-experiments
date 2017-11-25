using UnityEditor;
using Gemserk.Values;

[CustomEditor(typeof(TestContainerAsset), true)]
public class TestContainerAssetEditor : ValueContainerEditorBase {

	public override void AddNewElement()
	{
		TestContainerAsset container = (TestContainerAsset) target;
		container.valueContainer.values.Add (new ValueContainerUnity.ValueDefinitionEntry ());
	}

	public override void RemoveElement (int index)
	{
		TestContainerAsset container = (TestContainerAsset) target;
		container.valueContainer.values.RemoveAt (index);
	}

}