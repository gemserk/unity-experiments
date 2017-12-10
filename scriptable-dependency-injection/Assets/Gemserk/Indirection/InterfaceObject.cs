using UnityEngine;
using System;

namespace Gemserk
{
	[Serializable]
	public class InterfaceObject<T> where T : class
	{
		public UnityEngine.Object _object;

		T _instance;

		public T Get() {
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

		public void Set(T t) {
			_instance = t;
			_object = t as UnityEngine.Object;
		}
	}
		
}