using System;

namespace Gemserk.Values {

//	public enum ValueDefinitionType {
//		Constant,
//		Variable
//		Number,
//		Object
//	}

	// property drawer to select the inner value: int, float, string

	[Serializable]
	public class ValueDefinition : Value {

		public static int NUMBER_TYPE = 0;
		public static int OBJECT_TYPE = 1;

//		public string name;

//		public ValueDefinitionType type = ValueDefinitionType.Variable;

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
				throw new NotImplementedException ();
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