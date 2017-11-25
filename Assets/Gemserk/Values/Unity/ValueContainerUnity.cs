using System;
using System.Linq;
using System.Collections.Generic;

namespace Gemserk.Values 
{
	[Serializable]
	public class ValueContainerUnity : ValueContainer
	{
		[Serializable]
		public class ValueDefinitionEntry
		{
			public string name;
			public ValueUnity value;
		}

		public List<ValueDefinitionEntry> values = new List<ValueDefinitionEntry>();

		// TODO: optimize to get o(1) for get and for keys....

		public List<string> GetKeys ()
		{
			return values.Select (v => v.name).ToList ();
		}

		public Value Get (string key)
		{
			foreach (var v in values) {
				if (v.name.Equals (key)) {
					return v.value;
				}
			}

			return null;
		}
	}
}