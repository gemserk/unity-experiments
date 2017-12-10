using UnityEngine;
using System;

namespace Gemserk
{
	[Serializable]
	public class InterfaceReference
	{
		public UnityEngine.Object _object;

		object _cachedGameObject;

		public T Get<T>() where T : class
		{
			if (_object == null)
				return _cachedGameObject as T;
			
			var go = _object as GameObject;

			if (go != null) {
				_cachedGameObject = go.GetComponentInChildren<T> ();
			} else {
				_cachedGameObject = _object;
			}

			return _cachedGameObject as T;
		}

		public void Set<T>(T t) where T : class
		{
			_cachedGameObject = t;
			_object = t as UnityEngine.Object;
		}

	}


}