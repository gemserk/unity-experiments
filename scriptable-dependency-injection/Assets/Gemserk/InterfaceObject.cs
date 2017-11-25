using UnityEngine;

namespace Gemserk.Injector
{
	public class InterfaceObject<T> where T : class
	{
		public UnityEngine.Object reference;

		T _instance;

		public T i {
			get {
				if (_instance == null) {
					var go = reference as GameObject;
					if (go != null) {
						_instance = go.GetComponentInChildren<T> ();
					} else {
						_instance = reference as T;
					}
				}
				return _instance;
			}
		}
	}

}