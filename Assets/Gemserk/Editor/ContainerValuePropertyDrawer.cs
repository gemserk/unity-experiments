using UnityEngine;
using UnityEditor;
using Gemserk.Values;
using System.Linq;

[CustomPropertyDrawer(typeof(UnityContainerValue))]
public class ContainerValuePropertyDrawer : PropertyDrawer
{
	const float propertyHeight = 16;

	public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
	{
		var sourceType = property.FindPropertyRelative ("sourceType");
		var containerProperty = property.FindPropertyRelative ("container");
		var keyProperty = property.FindPropertyRelative ("key");

		var maxWidth = position.width;

		EditorGUI.BeginProperty (position, label, property);

		var sourceRect = new Rect(position.x + maxWidth * 0.75f, position.y + propertyHeight * 0, maxWidth * 0.25f, propertyHeight);

		sourceType.enumValueIndex = (int) ((UnityContainerValue.SourceType) EditorGUI.EnumPopup (sourceRect, (UnityContainerValue.SourceType) sourceType.enumValueIndex));

		bool containerReadonly = false;

		if (sourceType.enumValueIndex == (int)UnityContainerValue.SourceType.Global) {
			containerProperty.objectReferenceValue = GameObject.FindObjectOfType<GlobalValueContainerBehaviour> ();
			containerReadonly = true;
		}

		var containerRect = new Rect(position.x, position.y + propertyHeight * 0, maxWidth * 0.75f, propertyHeight);

		EditorGUI.BeginDisabledGroup (containerReadonly);
		containerProperty.objectReferenceValue = EditorGUI.ObjectField (containerRect, containerProperty.objectReferenceValue, typeof(ValueContainerBehaviour), true);
		EditorGUI.EndDisabledGroup ();

		var valueContainer = containerProperty.objectReferenceValue as ValueContainerBehaviour;

		var keyRect = new Rect(position.x, position.y + propertyHeight * 1, maxWidth, propertyHeight);

		if (valueContainer != null) {

			var options = valueContainer.values.Select (v => v.name).ToList ();
			options.Add ("None");

			int currentSelection = options.IndexOf (keyProperty.stringValue);

			if (currentSelection == -1)
				currentSelection = options.Count - 1;

			int newSelection = EditorGUI.Popup(keyRect, currentSelection, options.ToArray());

			if (newSelection != currentSelection) {
				if (newSelection == options.Count - 1)
					keyProperty.stringValue = "";
				else
					keyProperty.stringValue = options [newSelection];
			}

		}

		EditorGUI.EndProperty ();
	}

	public override float GetPropertyHeight (SerializedProperty property, GUIContent label)
	{
		int totalFields = 1;

		var containerProperty = property.FindPropertyRelative ("container");
		var valueContainer = containerProperty.objectReferenceValue as ValueContainerBehaviour;

		if (valueContainer != null) {
			totalFields = 2;
		}

		return propertyHeight * totalFields;
	}
}