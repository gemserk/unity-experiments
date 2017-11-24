
namespace Gemserk.Values
{

	public class VariableValue : Value {
		#region Value implementation
		public T Get<T> ()
		{
			throw new System.NotImplementedException ();
		}
		public ValueType Type {
			get {
				throw new System.NotImplementedException ();
			}
		}
		#endregion
		
	}
}
