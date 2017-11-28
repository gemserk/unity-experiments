
namespace Gemserk.Values {

	public interface ValueContainerUnityObject : ValueContainer
	{
		string Name {
			get;
		}

		ValueContainer ValueContainer {
			get;
		}
	}

}