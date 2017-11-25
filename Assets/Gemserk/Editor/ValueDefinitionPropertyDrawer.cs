using UnityEngine;
using UnityEditor;
using Gemserk.Values;

[CustomPropertyDrawer(typeof(ValueDefinition))]
public class ValueDefinitionPropertyDrawer : PropertyDrawer
{
	const float propertyHeight = 16;

	const int totalFields = 2;

	// Draw the property inside the given rect
	public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
	{
		var maxWidth = position.width;

		var nameProperty = property.FindPropertyRelative ("name");
		var numberValueProperty = property.FindPropertyRelative ("number");
		var objectValueProperty = property.FindPropertyRelative ("reference");
		var typeProperty = property.FindPropertyRelative ("type");

		EditorGUI.BeginProperty (position, label, property);

		var keyRect = new Rect(position.x, position.y + propertyHeight * 0, maxWidth / 2, propertyHeight);
		nameProperty.stringValue = EditorGUI.TextField(keyRect, nameProperty.stringValue);

		var typeRect = new Rect(position.x + maxWidth / 2, position.y + propertyHeight * 0, 
			maxWidth / 2, propertyHeight);
		
		typeProperty.intValue = EditorGUI.Popup (typeRect, typeProperty.intValue, new string[] { 
			"Number", 
			"Object", 
		});

		var valueRect = new Rect (position.x, position.y + propertyHeight * 1, 
			maxWidth, propertyHeight);

		if (typeProperty.intValue == 0) {
			numberValueProperty.floatValue = EditorGUI.FloatField (valueRect, numberValueProperty.floatValue);
			objectValueProperty.objectReferenceValue = null;
		} else if (typeProperty.intValue == 1) {
			numberValueProperty.floatValue = 0;
			objectValueProperty.objectReferenceValue = 
				EditorGUI.ObjectField (valueRect, objectValueProperty.objectReferenceValue, typeof(UnityEngine.Object), true);
		}
			
		EditorGUI.EndProperty ();
	}

	public override float GetPropertyHeight (SerializedProperty property, GUIContent label)
	{
		return propertyHeight * totalFields;
	}
}

