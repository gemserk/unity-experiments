using System;

namespace Gemserk.Values {

	[Serializable]
	public class ValueDefinition : Value {

		public static int NUMBER_TYPE = 0;
		public static int OBJECT_TYPE = 1;

		// used by editor
		public int type;

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
			type = ValueDefinition.NUMBER_TYPE;
			number = f;
		}

		public void Set<T> (T t) where T : class
		{
			type = ValueDefinition.OBJECT_TYPE;
			reference = t as UnityEngine.Object;
		}

		public ValueType ValueType {
			get {
				if (type == NUMBER_TYPE) {
					return ValueType.Number;
				} 
				return ValueType.Object;
			}
		}

		public void Override (Value value)
		{
			if (type == ValueDefinition.NUMBER_TYPE)
				value.SetFloat (GetFloat ());
			else if (type == ValueDefinition.OBJECT_TYPE)
				value.Set<object>(Get<object>());
		}

		#endregion
	}

}