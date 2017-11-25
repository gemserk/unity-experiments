
namespace Gemserk.Values
{
	public class VariableValue : Value {

		float _value;

		public VariableValue(float v)
		{
			_value = v;
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
			return null;
		}

		public ValueType ValueType {
			get {
				throw new System.NotImplementedException ();
			}
		}
		#endregion
		
	}
}
