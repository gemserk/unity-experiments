using UnityEngine;

public class ValueConsumerBehaviour : MonoBehaviour {

	public Gemserk.Values.ContainerValueUnity[] values;

	void Update() {
		if (Input.GetKeyUp(KeyCode.Alpha1)) {
			if (values[0].container != null)
				Debug.Log(values[0].GetFloat());
		}

		if (Input.GetKeyUp(KeyCode.Alpha2)) {
			if (values[1].container != null)
				Debug.Log(values[1].Get<GameObject>().name);
		}

	}

}