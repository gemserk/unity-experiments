using System.Collections;
using UnityEngine;
using UnityEditor;
using Gemserk.Values;

[CustomEditor(typeof(ValueContainerBehaviour), true)]
public class ValueContainerCustomInspector : Editor {

	public override void OnInspectorGUI() {

//		base.OnInspectorGUI ();

		ValueContainerBehaviour container = (ValueContainerBehaviour)target;

		var valuesProperty = this.serializedObject.FindProperty ("values");

		var iterator = valuesProperty.GetEnumerator ();

		int entryToRemove = -1;
		int current = 0;

		while (iterator.MoveNext()) {
			var valueEntry = iterator.Current as SerializedProperty;

			var nameProperty = valueEntry.FindPropertyRelative ("name");
			nameProperty.stringValue = EditorGUILayout.TextField (nameProperty.stringValue);

			var valueProperty = valueEntry.FindPropertyRelative ("value");
			EditorGUILayout.PropertyField (valueProperty, true);
		
			if (GUILayout.Button ("Remove")) {
				entryToRemove = current;
			}

			current++;
		}

		if (entryToRemove >= 0) {
			container.values.RemoveAt (entryToRemove);
		}

		if (GUILayout.Button ("Add")) {
			container.values.Add (new ValueContainerBehaviour.ValueDefinitionEntry ());
		}
	}
		
}