using System.Collections.Generic;

namespace Gemserk.Values
{
	public interface ValueContainer {
		
		List<string> GetKeys();

		Value Get(string key);

	}

}