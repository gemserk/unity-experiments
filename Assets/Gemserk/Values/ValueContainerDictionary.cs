using System.Collections.Generic;

namespace Gemserk.Values
{
	public class ValueContainerDictionary : ValueContainer {

		readonly Dictionary<string, Value> _values = new Dictionary<string, Value>();

		string _name;

		public ValueContainerDictionary(string name)
		{
			_name = name;
		}

		#region ValueContainer implementation

		public string Name {
			get {
				return _name;
			}
		}

		public List<string> GetKeys ()
		{
			return new List<string> (_values.Keys);
		}

		public Value Get (string key)
		{
			return _values [key];
		}
		#endregion

		public void Add(string key, Value value) {
			_values [key] = value;
		}
		
	}
}