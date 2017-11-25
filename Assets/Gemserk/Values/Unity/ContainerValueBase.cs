using System;

namespace Gemserk.Values
{
	[SerializableAttribute]
	public class ContainerValueBase : ContainerValue
	{
		public enum SourceType {
			Global, 
			Local
		}

		public SourceType sourceType;
		public ValueContainerBase container;

		protected override ValueContainer Container {
			get {
				return container;
			}
		}
	}
	
}
