using UnityEngine;

public abstract class InjectorAsset : ScriptableObject {

	public abstract void SetBindings(InjectorBindings bindings);

	public abstract void Inject (UnityEngine.Object o);

}