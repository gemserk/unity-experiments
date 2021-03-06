﻿using UnityEngine;
using UnityEditor;
using Gemserk.Values;

[CustomPropertyDrawer(typeof(ValueUnity))]
public class ValueUnityPropertyDrawer : PropertyDrawer
{
	const float propertyHeight = 16;

	const int totalFields = 1;

	// Draw the property inside the given rect
	public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
	{
		var maxWidth = position.width;

//		var valueDefinition = fieldInfo.GetValue () as ValueDefinition;

		var numberValueProperty = property.FindPropertyRelative ("number");
		var objectValueProperty = property.FindPropertyRelative ("reference");
		var typeProperty = property.FindPropertyRelative ("valueType");

		EditorGUI.BeginProperty (position, label, property);

		var valueRect = new Rect(position.x, position.y + propertyHeight * 0, maxWidth / 2, propertyHeight);
		var typeRect = new Rect(position.x + maxWidth / 2, position.y + propertyHeight * 0, maxWidth / 2, propertyHeight);
		
		typeProperty.intValue = EditorGUI.Popup (typeRect, typeProperty.intValue, new string[] { 
			"Number", 
			"Object", 
		});

		var valueType = (ValueType) typeProperty.enumValueIndex;

		if (valueType == ValueType.Number) {
			numberValueProperty.floatValue = EditorGUI.FloatField (valueRect, numberValueProperty.floatValue);
			objectValueProperty.objectReferenceValue = null;


		} else if (valueType == ValueType.Object) {
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