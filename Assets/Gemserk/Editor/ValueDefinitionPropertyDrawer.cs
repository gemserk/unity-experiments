using UnityEngine;
using UnityEditor;
using Gemserk.Values;

[CustomPropertyDrawer(typeof(ValueDefinition))]
public class ValueDefinitionPropertyDrawer : PropertyDrawer
{
	const float propertyHeight = 16;

	const int totalFields = 1;

	// Draw the property inside the given rect
	public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
	{
		var maxWidth = position.width;

		var numberValueProperty = property.FindPropertyRelative ("number");
		var objectValueProperty = property.FindPropertyRelative ("reference");
		var typeProperty = property.FindPropertyRelative ("type");

		EditorGUI.BeginProperty (position, label, property);

		var valueRect = new Rect(position.x, position.y + propertyHeight * 0, maxWidth / 2, propertyHeight);
		var typeRect = new Rect(position.x + maxWidth / 2, position.y + propertyHeight * 0, maxWidth / 2, propertyHeight);
		
		typeProperty.intValue = EditorGUI.Popup (typeRect, typeProperty.intValue, new string[] { 
			"Number", 
			"Object", 
		});

		if (typeProperty.intValue == ValueDefinition.NUMBER_TYPE) {
			numberValueProperty.floatValue = EditorGUI.FloatField (valueRect, numberValueProperty.floatValue);
			objectValueProperty.objectReferenceValue = null;
		} else if (typeProperty.intValue == ValueDefinition.OBJECT_TYPE) {
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

