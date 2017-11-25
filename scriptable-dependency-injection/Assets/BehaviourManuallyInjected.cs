using UnityEngine;

public class BehaviourManuallyInjected : MonoBehaviour {

	// [Inject]
	protected IMegaSystem megaSystem2;

	public InjectorAsset injector;

	// Use this for initialization
	void Start () {
		injector.Inject (this);
		Debug.Log ("SuperValue: " + megaSystem2.GetSuperValue());
	}

}
