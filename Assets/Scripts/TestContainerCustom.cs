using UnityEngine;
using Gemserk.Values;

namespace Gemserk.Values {

	public class TestContainerCustom : ValueContainerBase {
		
		#region implemented abstract members of ValueContainerBase

		public override System.Collections.Generic.List<string> GetKeys ()
		{
			return new System.Collections.Generic.List<string> () {
				{ "MyValue1" },
				{ "MyValue2" },
			};
		}

		public override Value Get (string key)
		{
			throw new System.NotImplementedException ();
		}

		#endregion
		
	}
}