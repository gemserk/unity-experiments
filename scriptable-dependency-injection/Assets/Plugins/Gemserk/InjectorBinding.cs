using System;

namespace Gemserk.Injector
{
	[Serializable]
	public class InjectorBinding {

		// binding by type, singleton or not
		// create binding empty, auto build first time injected?

		public string name;
		public UnityEngine.Object target;

	}

}