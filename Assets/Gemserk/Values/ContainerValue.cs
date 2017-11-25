
namespace Gemserk.Values
{
	public abstract class ContainerValue : Value
	{
		public string key;

		protected abstract ValueContainer Container {
			get;
		}

		#region Value implementation

//		public int GetInt ()
//		{
//			return Container.Get(key).GetInt();
//		}

		public float GetFloat ()
		{
			return Container.Get(key).GetFloat();
		}

		public T Get<T> () where T : class
		{
			return Container.Get(key).Get<T>();
		}

		public ValueType ValueType {
			get {
				return Container.Get (key).ValueType;
			}
		}
		#endregion
	}
}
