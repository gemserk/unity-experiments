using Gemserk.Values;

namespace Gemserk.Values {

	public class TestContainerCustom : ValueContainerBase {

		#region implemented abstract members of ValueContainerBase

		readonly Value _health = new VariableValue(0, null);
		readonly Value _speed = new VariableValue(10, null);

		public override System.Collections.Generic.List<string> GetKeys ()
		{
			return new System.Collections.Generic.List<string> () {
				{ "Health" },
				{ "Speed" },
			};
		}

		public override Value Get (string key)
		{
			if (key.Equals ("Health"))
				return _health;

			if (key.Equals ("Speed"))
				return _speed;
			
			return null;
		}

		#endregion
		
	}
}