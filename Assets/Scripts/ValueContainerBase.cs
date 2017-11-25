using UnityEngine;

namespace Gemserk.Values {

	public abstract class ValueContainerBase : MonoBehaviour, ValueContainer
	{
		#region ValueContainer implementation

		public string Name {
			get {
				return gameObject.name;
			}
		}

		public abstract System.Collections.Generic.List<string> GetKeys ();

		public abstract Value Get (string key);

		#endregion
	}

}