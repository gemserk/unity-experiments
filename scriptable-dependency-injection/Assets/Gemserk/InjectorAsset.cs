using UnityEngine;
using System;

[CreateAssetMenu(menuName="Gemserk/Injector")]
public class InjectorAsset : ScriptableObject {

	// custom Injection system...

	// objeto en pantalla registrado por tipo o por nombre

//	public InjectorBindings bindings;
	InjectorBindings _bindings;

	public void SetBindings(InjectorBindings bindings) {
		_bindings = bindings;
	}

	public void Inject (UnityEngine.Object o) 
	{
		var t = o.GetType ();
//		t.GetField(

		foreach (var binding in _bindings.bindings) {
			var field = t.GetField (binding.name, System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
			if (field != null) {
				field.SetValue (o, binding.target);
			}
		}
	}
}