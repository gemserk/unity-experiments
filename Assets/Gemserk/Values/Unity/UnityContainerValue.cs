using System;

namespace Gemserk.Values
{
	[SerializableAttribute]
	public class UnityContainerValue : ContainerValue
	{
		public enum SourceType {
			Global, 
			Local
		}

		public SourceType sourceType;
		public ValueContainerBehaviour container;

		protected override ValueContainer Container {
			get {
				return container;
			}
		}
	}
	
}
