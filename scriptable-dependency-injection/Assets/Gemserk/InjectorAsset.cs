using UnityEngine;

namespace Gemserk.Injector
{
	public abstract class InjectorAsset : ScriptableObject {

		// this one could be implemented to have other injector implementations

		public abstract void SetBindings(InjectorBindings bindings);

		public abstract void Inject (UnityEngine.Object o);

	}
}