using UnityEngine;

public class Example2CleanBehaviour : MonoBehaviour {

	public GameObject objectFound;

	public void MethodForSignal1(Health health)
	{
		Debug.Log(string.Format("Character {0} has {1} health", health.unit.name, health.current));
//		GameObject go = o as GameObject;
//
//		if (go != null) {
//			objectFound = go;
//		}
	}

	public void OtherMethodToSelect(Health health)
	{
		Debug.Log(string.Format("Character {0} blah blah has {1} health", health.unit.name, health.current));
		//		GameObject go = o as GameObject;
		//
		//		if (go != null) {
		//			objectFound = go;
		//		}
	}

	public void MethodForObject(object o)
	{
		
	}

}
