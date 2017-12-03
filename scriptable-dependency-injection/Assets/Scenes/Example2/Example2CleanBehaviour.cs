using UnityEngine;

public class Example2CleanBehaviour : MonoBehaviour {

	public GameObject objectFound;

	public void MethodForSignal1(UnityEngine.Object o)
	{
		GameObject go = o as GameObject;

		if (go != null) {
			objectFound = go;
		}
	}

}
