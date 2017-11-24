
namespace Gemserk.Values
{
	public interface Value {

		T Get<T>();

		ValueType Type {
			get;
		}

	}

}
