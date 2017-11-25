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
			var valueProperty = valueEntry.FindPropertyRelative ("value");

			var emptyName = string.IsNullOrEmpty (nameProperty.stringValue);

			EditorGUILayout.BeginHorizontal ();
			nameProperty.stringValue = EditorGUILayout.TextField (nameProperty.stringValue);

			if (GUILayout.Button ("Remove")) {
				entryToRemove = current;
			}
			EditorGUILayout.EndHorizontal();

			if (!emptyName) {
				EditorGUILayout.PropertyField (valueProperty, true);
			}
	
			current++;

			if (emptyName) {
				EditorGUILayout.HelpBox("Name is empty!", MessageType.Warning);
			}
		}
	
		if (entryToRemove >= 0) {
			if (EditorUtility.DisplayDialog ("Warning", "Are sure to remove value?", "Yes", "Cancel")) {
				container.values.RemoveAt (entryToRemove);
			}
		}

		if (GUILayout.Button ("Add")) {
			container.values.Add (new ValueContainerBehaviour.ValueDefinitionEntry ());
		}

		serializedObject.ApplyModifiedProperties ();
		EditorUtility.SetDirty (target);
	}
		
}