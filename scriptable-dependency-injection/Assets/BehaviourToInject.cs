using UnityEngine;

public class BehaviourToInject : InectedBehaviour {

	// [Inject]
	protected IMegaSystem megaSystem;

	// Use this for initialization
	void Start () {
		Debug.Log ("SuperValue: " + megaSystem.GetSuperValue());
	}

}
