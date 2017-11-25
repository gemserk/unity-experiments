using UnityEngine;
using System;

namespace Gemserk.Values
{


	[SerializableAttribute]
	public class ValueGetter : ContainerValue
	{

	}

	public class ValueConsumerBehaviour : MonoBehaviour {

		public ValueGetter valueGetter;

		// Use this for initialization
		void Start () {
			Debug.Log(valueGetter.GetFloat());
		}

	}
}
