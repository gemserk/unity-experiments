using UnityEngine;
using UnityEditor;
using Gemserk.Values;
using System.Linq;
using System.Collections.Generic;

[CustomPropertyDrawer(typeof(ContainerValueUnity))]
public class ContainerValueUnityPropertyDrawer : PropertyDrawer
{
	const float propertyHeight = 16;

	public class ContainerVariable 
	{
		public string name;
		public string key;
		public UnityEngine.Object container;
	}

	public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
	{
		var sourceType = property.FindPropertyRelative ("sourceType");
		var containerProperty = property.FindPropertyRelative ("container");
		var keyProperty = property.FindPropertyRelative ("key");

		var maxWidth = position.width;

		EditorGUI.BeginProperty (position, label, property);

		var containerRect = new Rect(position.x, position.y + propertyHeight * 0, maxWidth * 0.75f, propertyHeight);
		var sourceTypeRect = new Rect(position.x + maxWidth * 0.75f, position.y + propertyHeight * 0, maxWidth * 0.25f, propertyHeight);
		var keyRect = new Rect(position.x, position.y + propertyHeight * 1, maxWidth * 0.5f, propertyHeight);
		var valueRect = new Rect(position.x + maxWidth * 0.5f, position.y + propertyHeight * 1, maxWidth * 0.5f, propertyHeight);

		sourceType.enumValueIndex = (int) ((ContainerValueUnity.SourceType) EditorGUI.EnumPopup (sourceTypeRect, (ContainerValueUnity.SourceType) sourceType.enumValueIndex));

		bool isGlobal = sourceType.enumValueIndex == (int)ContainerValueUnity.SourceType.Global;
	
		GlobalValueContainerBehaviour[] globalContainers = null;

		if (isGlobal) {
			// performance cost here, maybe we could have a component to hold all the containers and the global containers
			// register themselves in this component or something like that.
			globalContainers = GameObject.FindObjectsOfType<GlobalValueContainerBehaviour>();
		
			var variables = new List<ContainerVariable> ();

			globalContainers.ToList().ForEach (gc => {
				gc.valueContainer.GetKeys().ForEach(k => 
					{ 
						variables.Add(new ContainerVariable() {
							name = string.Format("{0}.{1}", gc.name, k),
							key = k,
							container = gc
					});
				});
			});

			variables.Add (new ContainerVariable () { 
				name = "None",
				key = "",
				container = null
			});

			var selection = variables.FindIndex (v => v.container == containerProperty.objectReferenceValue && v.key == keyProperty.stringValue);

			if (selection == -1)
				selection = variables.Count - 1;

			var options = variables.Select (v => v.name).ToList();

			var newSelection = EditorGUI.Popup(keyRect, selection, options.ToArray());

			if (newSelection != selection) {
				if (newSelection == variables.Count - 1) {
					containerProperty.objectReferenceValue = null;
					keyProperty.stringValue = "";
				} else {
					var newVariable = variables [newSelection];
					containerProperty.objectReferenceValue = newVariable.container;
					keyProperty.stringValue = newVariable.key;
				}
			}

		}
			
//
//		if (valueContainer != null) {
//			var options = valueContainer.GetKeys ();
//
//			int currentSelection = options.IndexOf (keyProperty.stringValue);
//
//			string name = null;
//
//			if (valueContainer is UnityEngine.Object) {
//				name = (valueContainer as UnityEngine.Object).name;
//			}
//
//			var modifiedOptons = options.Select (o => {
//				if (string.IsNullOrEmpty(name))
//					return o;
//				return string.Format("{1}.{0}", o, name);
//			}).ToList ();
//
//			modifiedOptons.Add ("None");
//
//			if (currentSelection == -1)
//				currentSelection = modifiedOptons.Count - 1;
//
//			int newSelection = EditorGUI.Popup(keyRect, currentSelection, modifiedOptons.ToArray());
//
//			if (newSelection != currentSelection) {
//				if (newSelection == modifiedOptons.Count - 1)
//					keyProperty.stringValue = "";
//				else
//					keyProperty.stringValue = options [newSelection];
//			}
//
//			if (!string.IsNullOrEmpty (keyProperty.stringValue)) {
//				DrawValuePreview (valueRect, valueContainer.Get(keyProperty.stringValue));
//			}
//
//		}

		EditorGUI.BeginDisabledGroup (isGlobal);
		var newObjectReference = EditorGUI.ObjectField (containerRect, containerProperty.objectReferenceValue, typeof(UnityEngine.Object), true);
		if (newObjectReference is ValueContainer)
			containerProperty.objectReferenceValue = newObjectReference;
		EditorGUI.EndDisabledGroup ();

		var valueContainer = containerProperty.objectReferenceValue as ValueContainer;

		if (!string.IsNullOrEmpty (keyProperty.stringValue) && containerProperty.objectReferenceValue != null) {
			DrawValuePreview (valueRect, valueContainer.Get(keyProperty.stringValue));
		}

		EditorGUI.EndProperty ();
	}

	void DrawValuePreview(Rect position, Value value)
	{
		EditorGUI.BeginDisabledGroup (true);
		// just in case the key is available but the value not set yet (is set in runtime)...
		if (value != null) {
			// check types ...
			if (value.ValueType == ValueType.Number) {
				EditorGUI.FloatField (position, value.GetFloat ());
			} else if (value.ValueType == ValueType.Object) {
				var valueObject = value.Get<object> ();
				if (valueObject is UnityEngine.Object) {
					EditorGUI.ObjectField (position, valueObject as UnityEngine.Object, typeof(UnityEngine.Object), true);
				}
			}
		}
		EditorGUI.EndDisabledGroup ();
	}

	public override float GetPropertyHeight (SerializedProperty property, GUIContent label)
	{
		int totalFields = 2;

//		var containerProperty = property.FindPropertyRelative ("container");
//		var valueContainer = containerProperty.objectReferenceValue as ValueContainer;
//
//		if (valueContainer != null) {
//			totalFields = 2;
//		}
//
		return propertyHeight * totalFields;
	}
}