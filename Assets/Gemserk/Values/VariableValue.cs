
namespace Gemserk.Values
{
	public class VariableValue : Value {

		float _number;
		object _object;

		ValueType _valueType;

		public VariableValue(float v, object o)
		{
			_number = v;
			_object = o;

			if (o != null) {
				_valueType = ValueType.Object;
			} else {
				_valueType = ValueType.Number;
			}
		}

		#region Value implementation

		public float GetFloat ()
		{
			return _number;
		}

		public T Get<T>() where T : class
		{
			return _object as T;
		}

		public void SetFloat (float f)
		{
			_number = f;
			// lose reference, just in case...
			_object = null;
			_valueType = ValueType.Number;
		}

		public void Set<T> (T t) where T : class
		{
			_object = t;
			_valueType = ValueType.Object;
		}

		public ValueType ValueType {
			get {
				return _valueType;
			}
		}
		#endregion
		
	}
}
