
namespace Gemserk.Values
{
	public interface Value {

		int GetInt();

		float GetFloat();

		T Get<T>() where T : class;

		ValueType ValueType {
			get;
		}

	}

}
