using UnityEngine;

namespace Gemserk.Values
{
	public class ValueConsumerBehaviour : MonoBehaviour {

		public UnityContainerValue myValue;

		public UnityContainerValue myValue2;

		// Use this for initialization
		void Start () 
		{
			if (myValue.container != null)
				Debug.Log(myValue.GetFloat());

			if (myValue2.container != null)
				Debug.Log(myValue2.Get<GameObject>().name);
		}

	}
}
