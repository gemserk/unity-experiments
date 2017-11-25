
namespace Gemserk.Values
{
	public class ConstantValue : Value {

		#region Value implementation

		public int GetInt ()
		{
			throw new System.NotImplementedException ();
		}

		public float GetFloat ()
		{
			throw new System.NotImplementedException ();
		}
		public T Get<T> () where T : class
		{
			throw new System.NotImplementedException ();
		}
		public ValueType ValueType {
			get {
				throw new System.NotImplementedException ();
			}
		}
		#endregion
		
	}

}
