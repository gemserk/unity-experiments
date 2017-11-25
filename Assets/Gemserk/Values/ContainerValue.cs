
namespace Gemserk.Values
{
	public class ContainerValue : Value
	{
		public ValueContainerBehaviour container;
		public string key;

		#region Value implementation

		public int GetInt ()
		{
			return container.Get(key).GetInt();
		}

		public float GetFloat ()
		{
			return container.Get(key).GetFloat();
		}

		public T Get<T> () where T : class
		{
			return container.Get(key).Get<T>();
		}

		public ValueType ValueType {
			get {
				return container.Get (key).ValueType;
			}
		}
		#endregion
	}
}
