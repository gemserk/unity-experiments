using UnityEngine;
using System;

namespace Gemserk.Values
{
	[SerializableAttribute]
	public class SerializableContainerValue : ContainerValue
	{
		public ValueContainerBehaviour container;

		protected override ValueContainer Container {
			get {
				return container;
			}
		}
	}

	public class ValueConsumerBehaviour : MonoBehaviour {

		public SerializableContainerValue valueGetter;

		// Use this for initialization
		void Start () {
			Debug.Log(valueGetter.GetFloat());
		}

	}
}
