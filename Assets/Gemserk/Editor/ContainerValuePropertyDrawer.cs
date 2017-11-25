using UnityEngine;
using UnityEditor;
using Gemserk.Values;

[CustomPropertyDrawer(typeof(SerializableContainerValue))]
public class ContainerValuePropertyDrawer : PropertyDrawer
{
	const float propertyHeight = 16;

	int totalFields = 1;

	// Draw the property inside the given rect
	public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
	{
		var containerProperty = property.FindPropertyRelative ("container");
		var keyProperty = property.FindPropertyRelative ("key");

		EditorGUI.BeginProperty (position, label, property);

		var maxWidth = position.width;

		var containerRect = new Rect(position.x, position.y + propertyHeight * 0, maxWidth, propertyHeight);

		EditorGUI.ObjectField (containerRect, containerProperty, typeof(ValueContainerBehaviour));

		if (containerProperty == null) {
			totalFields = 1;
		} else {
			totalFields = 2;
			var keyRect = new Rect(position.x, position.y + propertyHeight * 1, maxWidth, propertyHeight);

			// TODO: show select from all defined variables in container
			keyProperty.stringValue = EditorGUI.TextField(keyRect, keyProperty.stringValue);
		}

		EditorGUI.EndProperty ();
	}

	public override float GetPropertyHeight (SerializedProperty property, GUIContent label)
	{
		return propertyHeight * totalFields;
	}
}