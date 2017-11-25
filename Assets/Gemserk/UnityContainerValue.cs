using UnityEngine;
using System;

namespace Gemserk.Values
{
	[SerializableAttribute]
	public class UnityContainerValue : ContainerValue
	{
		public ValueContainerBehaviour container;

		protected override ValueContainer Container {
			get {
				return container;
			}
		}
	}
	
}
