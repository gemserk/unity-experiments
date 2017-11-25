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

		var sourceRect = new Rect(position.x + maxWidth * 0.75f, position.y + propertyHeight * 0, maxWidth * 0.25f, propertyHeight);

		sourceType.enumValueIndex = (int) ((ContainerValueBase.SourceType) EditorGUI.EnumPopup (sourceRect, (ContainerValueBase.SourceType) sourceType.enumValueIndex));

		bool containerReadonly = false;

		bool isGlobal = sourceType.enumValueIndex == (int)ContainerValueBase.SourceType.Global;
	
		if (isGlobal) {
			containerProperty.objectReferenceValue = GameObject.FindObjectOfType<GlobalValueContainerBehaviour> ();
			containerReadonly = true;
		}

		var containerRect = new Rect(position.x, position.y + propertyHeight * 0, maxWidth * 0.75f, propertyHeight);

		EditorGUI.BeginDisabledGroup (containerReadonly);
		containerProperty.objectReferenceValue = EditorGUI.ObjectField (containerRect, containerProperty.objectReferenceValue, typeof(ValueContainerBase), true);
		EditorGUI.EndDisabledGroup ();

		isGlobal = containerProperty.objectReferenceValue is GlobalValueContainerBehaviour;

		var valueContainer = containerProperty.objectReferenceValue as ValueContainer;

		var keyRect = new Rect(position.x, position.y + propertyHeight * 1, maxWidth * 0.5f, propertyHeight);
		var valueRect = new Rect(position.x + maxWidth * 0.5f, position.y + propertyHeight * 1, maxWidth * 0.5f, propertyHeight);

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

			EditorGUI.BeginDisabledGroup (true);
			if (!string.IsNullOrEmpty (keyProperty.stringValue)) {
				// check types ...
				EditorGUI.FloatField (valueRect, valueContainer.Get (keyProperty.stringValue).GetFloat ());
			}
			EditorGUI.EndDisabledGroup ();

		}

		EditorGUI.EndProperty ();
	}

	public override float GetPropertyHeight (SerializedProperty property, GUIContent label)
	{
		int totalFields = 1;

		var containerProperty = property.FindPropertyRelative ("container");
		var valueContainer = containerProperty.objectReferenceValue as ValueContainerBase;

		if (valueContainer != null) {
			totalFields = 2;
		}

		return propertyHeight * totalFields;
	}
}