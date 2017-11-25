using UnityEngine;
using UnityEditor;
using Gemserk.Values;
using System.Linq;

[CustomPropertyDrawer(typeof(ContainerValueBase))]
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

		var sourceTypeRect = new Rect(position.x + maxWidth * 0.75f, position.y + propertyHeight * 0, maxWidth * 0.25f, propertyHeight);
		var keyRect = new Rect(position.x, position.y + propertyHeight * 1, maxWidth * 0.5f, propertyHeight);
		var valueRect = new Rect(position.x + maxWidth * 0.5f, position.y + propertyHeight * 1, maxWidth * 0.5f, propertyHeight);

		sourceType.enumValueIndex = (int) ((ContainerValueBase.SourceType) EditorGUI.EnumPopup (sourceTypeRect, (ContainerValueBase.SourceType) sourceType.enumValueIndex));

		bool containerReadonly = false;

		bool isGlobal = sourceType.enumValueIndex == (int)ContainerValueBase.SourceType.Global;
	
		if (isGlobal) {
			containerProperty.objectReferenceValue = GameObject.FindObjectOfType<GlobalValueContainerBehaviour> ();
			containerReadonly = true;
		}

		var containerRect = new Rect(position.x, position.y + propertyHeight * 0, maxWidth * 0.75f, propertyHeight);

		EditorGUI.BeginDisabledGroup (containerReadonly);
		var newObjectReference = EditorGUI.ObjectField (containerRect, containerProperty.objectReferenceValue, typeof(UnityEngine.Object), true);
		if (newObjectReference is ValueContainer)
			containerProperty.objectReferenceValue = newObjectReference;
		EditorGUI.EndDisabledGroup ();

		isGlobal = containerProperty.objectReferenceValue is GlobalValueContainerBehaviour;

		var valueContainer = containerProperty.objectReferenceValue as ValueContainer;


		if (valueContainer != null) {
			var options = valueContainer.GetKeys ();

			int currentSelection = options.IndexOf (keyProperty.stringValue);

			var modifiedOptons = options.Select (o => string.Format("{1}.{0}", o, (isGlobal ? "Global" : valueContainer.Name))).ToList ();

			modifiedOptons.Add ("None");

			if (currentSelection == -1)
				currentSelection = modifiedOptons.Count - 1;

			int newSelection = EditorGUI.Popup(keyRect, currentSelection, modifiedOptons.ToArray());

			if (newSelection != currentSelection) {
				if (newSelection == modifiedOptons.Count - 1)
					keyProperty.stringValue = "";
				else
					keyProperty.stringValue = options [newSelection];
			}

			if (!string.IsNullOrEmpty (keyProperty.stringValue)) {
				DrawValuePreview (valueRect, valueContainer.Get(keyProperty.stringValue));
			}

		}

		EditorGUI.EndProperty ();
	}

	void DrawValuePreview(Rect valueRect, Value value)
	{
		EditorGUI.BeginDisabledGroup (true);
		// just in case the key is available but the value not set yet (is set in runtime)...
		if (value != null) {
			// check types ...
			if (value.ValueType == ValueType.Number) {
				EditorGUI.FloatField (valueRect, value.GetFloat ());
			} else if (value.ValueType == ValueType.Object) {
				var valueObject = value.Get<object> ();
				if (valueObject is UnityEngine.Object) {
					EditorGUI.ObjectField (valueRect, valueObject as UnityEngine.Object, typeof(UnityEngine.Object), true);
				}
			}
		}
		EditorGUI.EndDisabledGroup ();
	}

	public override float GetPropertyHeight (SerializedProperty property, GUIContent label)
	{
		int totalFields = 1;

		var containerProperty = property.FindPropertyRelative ("container");
		var valueContainer = containerProperty.objectReferenceValue as ValueContainer;

		if (valueContainer != null) {
			totalFields = 2;
		}

		return propertyHeight * totalFields;
	}
}