using Gemserk.Values;
using UnityEngine;

namespace Gemserk.Values {

	public class TestContainerCustom : MonoBehaviour, ValueContainer {

		#region implemented abstract members of ValueContainerBase

		readonly Value _health = new VariableValue(0, null);
		readonly Value _speed = new VariableValue(10, null);

		Value _megaValue; 

		public System.Collections.Generic.List<string> GetKeys ()
		{
			return new System.Collections.Generic.List<string> () {
				{ "Health" },
				{ "Speed" },
				{ "MegaValue" },
			};
		}

		public Value Get (string key)
		{
			if (key.Equals ("Health"))
				return _health;

			if (key.Equals ("Speed"))
				return _speed;

			if (key.Equals ("MegaValue"))
				return _megaValue;
			
			return null;
		}

		public string Name {
			get { 
				return gameObject.name;
			}
		}

		#endregion

		void Awake()
		{
			_megaValue = new VariableValue (9999, null);
		}

	}
}