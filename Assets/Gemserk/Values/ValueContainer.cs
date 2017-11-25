using System.Collections.Generic;

namespace Gemserk.Values
{
	public interface ValueContainer {

		string Name {
			get;
		}

		List<string> GetKeys();

		Value Get(string key);

	}

}