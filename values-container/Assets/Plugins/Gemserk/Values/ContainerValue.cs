
namespace Gemserk.Values
{
	public abstract class ContainerValue : Value
	{
		public string key;

		protected abstract ValueContainer Container {
			get;
		}

		protected Value Value {
			get { 
				return Container.Get (key);
			}
		}

		#region Value implementation

		public float GetFloat ()
		{
			return Value.GetFloat();
		}

		public T Get<T> () where T : class
		{
			return Value.Get<T>();
		}

		public void SetFloat (float f)
		{
			Value.SetFloat(f);
		}

		public void Set<T> (T t) where T : class
		{
			Value.Set<T>(t);
		}

		public ValueType ValueType {
			get {
				return Container.Get (key).ValueType;
			}
		}
		#endregion
	}
}
