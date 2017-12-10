
namespace Gemserk.Signals
{
	public interface ISignalListener<T> where T : class
	{
		void OnSignal(T t);
	}

}