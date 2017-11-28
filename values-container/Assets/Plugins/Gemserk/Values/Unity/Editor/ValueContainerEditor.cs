using System.Collections;
using UnityEngine;
using UnityEditor;

public abstract class ValueContainerEditor : Editor
{
	public override void OnInspectorGUI() {

		EditorGUILayout.PropertyField (serializedObject.FindProperty ("optionalName"));

		var valuesProperty = this.serializedObject.FindProperty ("valueContainer.values");

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
				RemoveElement (entryToRemove);
			}
		}

		if (GUILayout.Button ("Add")) {
			AddNewElement ();
		}

		serializedObject.ApplyModifiedProperties ();
		EditorUtility.SetDirty (target);
	}

	public abstract void AddNewElement ();

	public abstract void RemoveElement (int index);

}
