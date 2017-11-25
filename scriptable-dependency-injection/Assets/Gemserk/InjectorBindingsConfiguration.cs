using UnityEngine;

public class InjectorBindingsConfiguration : MonoBehaviour
{
	public InjectorBindings bindings;
	public InjectorAsset injector;

	void Awake()
	{
		injector.SetBindings (bindings);
	}
}