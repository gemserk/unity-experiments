using UnityEngine;
using Gemserk.Injector;
using System;

[Serializable]
public class InterfaceObjectMegaSystem : InterfaceObject<IMegaSystem>
{
	
}

public class BehaviourManuallyInjected : MonoBehaviour {

	// [Inject]
	protected IMegaSystem megaSystem2;

	public InterfaceObjectMegaSystem megaSystem1;

	public InterfaceObject<IMegaSystem> megaSystem3;

	public InterfaceReference megaSystem4;

	public InjectorAsset injector;

	// Use this for initialization
	void Start () {
		injector.Inject (this);
		Debug.Log ("SuperValue: " + megaSystem2.GetSuperValue());
		Debug.Log ("SuperValue: " + megaSystem1.i.GetSuperValue());
	
		Debug.Log ("SuperValue: " + megaSystem4.Get<IMegaSystem>().GetSuperValue());
	}

}
