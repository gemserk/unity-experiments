using System;

namespace Gemserk.Values {

	[Serializable]
	public class ValueUnity : Value {

		public ValueType valueType;

		public float number;
		public UnityEngine.Object reference;

		#region Value implementation
		public float GetFloat ()
		{
			return number;
		}

		public T Get<T> () where T : class
		{
			return reference as T;
		}

		public void SetFloat (float f)
		{
			valueType = ValueType.Number;
			number = f;
		}

		public void Set<T> (T t) where T : class
		{
			valueType = ValueType.Object;
			reference = t as UnityEngine.Object;
		}

		public ValueType ValueType {
			get {
				return valueType;
			}
		}

		public void Override (Value value)
		{
			if (ValueType == ValueType.Number)
				value.SetFloat (GetFloat ());
			else if (ValueType == ValueType.Object)
				value.Set<object>(Get<object>());
		}

		#endregion
	}

}