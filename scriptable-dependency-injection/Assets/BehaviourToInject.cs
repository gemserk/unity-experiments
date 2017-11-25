﻿using UnityEngine;
using Gemserk.Injector;

public class BehaviourToInject : InjectableBehaviour {

	// [Inject]
	protected IMegaSystem megaSystem;

	// Use this for initialization
	void Start () {
		Debug.Log ("SuperValue: " + megaSystem.GetSuperValue());
	}

}