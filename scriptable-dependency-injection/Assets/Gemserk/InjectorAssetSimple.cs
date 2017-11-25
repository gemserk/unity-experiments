using UnityEngine;
using System;

namespace Gemserk.Injector
{
	[CreateAssetMenu(menuName="Gemserk/Injector Simple")]
	public class InjectorAssetSimple : InjectorAsset
	{
		// multiple bindings (from different configurations)
		// who is in charge of calling the auto inject? (behaviour order probably)

		// binding configurations from assets too

		InjectorBindings _bindings;

		public override void SetBindings(InjectorBindings bindings) {
			_bindings = bindings;
		}

		public override void Inject (UnityEngine.Object o) 
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
}