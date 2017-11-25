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
		//base.OnGUI (position, property, label);

		var nameProperty = property.FindPropertyRelative ("name");
		var numberValueProperty = property.FindPropertyRelative ("number");

		EditorGUI.BeginProperty (position, label, property);

		var maxWidth = position.width;

		// position = EditorGUI.PrefixLabel(position, GUIUtility.GetControlID(FocusType.Passive), label);

		var keyRect = new Rect(position.x, position.y + propertyHeight * 0, maxWidth / 2, propertyHeight);
//		EditorGUI.PropertyField(keyRect, property.FindPropertyRelative("name"));

		nameProperty.stringValue = EditorGUI.TextField(keyRect, nameProperty.stringValue);

//		var typeRect = new Rect(position.width - 80, position.y, 80, propertyHeight);
//		EditorGUI.Popup (typeRect, 0, new string[] { 
////			"Int", 
//			"Float", 
////			"String"
//		});

		var valueRect = new Rect(position.x + maxWidth / 2, position.y + propertyHeight * 0, maxWidth / 2, propertyHeight);

		numberValueProperty.floatValue = 
			EditorGUI.FloatField(valueRect, numberValueProperty.floatValue);

		EditorGUI.EndProperty ();
	}

	public override float GetPropertyHeight (SerializedProperty property, GUIContent label)
	{
		return propertyHeight * totalFields;
	}
}

