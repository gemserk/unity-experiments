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
			number = f;
		}

		public void Set<T> (T t) where T : class
		{
			reference = t as UnityEngine.Object;
		}

		public ValueType ValueType {
			get {
				throw new NotImplementedException ();
			}
		}

		#endregion
	}

}