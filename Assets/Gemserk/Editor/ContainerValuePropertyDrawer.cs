using UnityEngine;
using UnityEditor;
using Gemserk.Values;
using System.Linq;

[CustomPropertyDrawer(typeof(UnityContainerValue))]
public class ContainerValuePropertyDrawer : PropertyDrawer
{
	const float propertyHeight = 16;

	// Draw the property inside the given rect
	public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
	{
		var containerProperty = property.FindPropertyRelative ("container");
		var keyProperty = property.FindPropertyRelative ("key");

		EditorGUI.BeginProperty (position, label, property);

		var maxWidth = position.width;

		var containerRect = new Rect(position.x, position.y + propertyHeight * 0, maxWidth, propertyHeight);

		containerProperty.objectReferenceValue = EditorGUI.ObjectField (containerRect, containerProperty.objectReferenceValue, typeof(ValueContainerBehaviour), true);

		var valueContainer = containerProperty.objectReferenceValue as ValueContainerBehaviour;

		var keyRect = new Rect(position.x, position.y + propertyHeight * 1, maxWidth, propertyHeight);

		if (valueContainer != null) {

			if (valueContainer.values.Count == 0) {
				EditorGUI.LabelField (keyRect, "Empty Container");
			} else {
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