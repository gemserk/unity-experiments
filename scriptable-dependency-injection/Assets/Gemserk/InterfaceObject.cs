using UnityEngine;
using System;

namespace Gemserk.Injector
{
	[Serializable]
	public class InterfaceObject<T> where T : class
	{
		public UnityEngine.Object _object;

		T _instance;

		public T i {
			get {
				if (_instance == null) {
					var go = _object as GameObject;
					if (go != null) {
						_instance = go.GetComponentInChildren<T> ();
					} else {
						_instance = _object as T;
					}
				}
				return _instance;
			}
		}
	}
		
}