
namespace Gemserk.Values
{
	public class VariableValue : Value {

		float _value;
		object _object;

		public VariableValue(float v, object o)
		{
			_value = v;
			_object = o;
		}

		#region Value implementation

		public int GetInt ()
		{
			return (int) _value;
		}

		public float GetFloat ()
		{
			return _value;
		}

		public T Get<T>() where T : class
		{
			return _object as T;
		}

		public ValueType ValueType {
			get {
				throw new System.NotImplementedException ();
			}
		}
		#endregion
		
	}
}
