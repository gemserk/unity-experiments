using UnityEditor;
using Gemserk;
using UnityEngine;

[CustomPropertyDrawer(typeof(InterfaceReference), true)]
public class InterfaceReferenceDrawer : PropertyDrawer
{
	public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
	{
		var objectProperty = property.FindPropertyRelative ("_object");

		EditorGUI.PropertyField (position, objectProperty, label);

		if (objectProperty.objectReferenceValue == null)
			return;

		var filterAttributes = fieldInfo.GetCustomAttributes(typeof(FilterTypeProperty), true);

		if (filterAttributes.Length == 0)
			return;

		var filterProperty = filterAttributes [0] as FilterTypeProperty;

		if (filterProperty != null) {
			var referenceType = objectProperty.objectReferenceValue.GetType ();

			var assignableFrom = filterProperty.filterType.IsAssignableFrom(referenceType);

			if (assignableFrom)
				return;

//			var isSubclassOf = referenceType.IsSubclassOf(filterProperty.filterType);
//
//			if (isSubclassOf)
//				return;

			var gameObject = objectProperty.objectReferenceValue as GameObject;

			if (gameObject == null) {
				objectProperty.objectReferenceValue = null;
				return;
			}

			var instance = gameObject.GetComponentInChildren (filterProperty.filterType);
			if (instance != null)
				objectProperty.objectReferenceValue = instance;
		}

	}
}