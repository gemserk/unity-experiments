using System;

namespace Gemserk.Values
{
	[SerializableAttribute]
	public class ContainerValueUnity : ContainerValue
	{
		public enum SourceType {
			Global, 
			Local,
			Specific
		}

		public SourceType sourceType;
		public UnityEngine.Object container;

		protected override ValueContainer Container {
			get {
				return container as ValueContainer;
			}
		}
	}
	
}
