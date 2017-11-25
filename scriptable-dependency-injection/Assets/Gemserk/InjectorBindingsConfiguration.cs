using UnityEngine;

namespace Gemserk.Injector
{
	public class InjectorBindingsConfiguration : MonoBehaviour
	{
		public InjectorBindings bindings;
		public InjectorAsset injector;

		void Awake()
		{
			injector.SetBindings (bindings);
			var injectables = FindObjectsOfType<InjectableBehaviour> ();
			foreach (var injectable in injectables) {
				injector.Inject (injectable);
			}
		}
	}
}