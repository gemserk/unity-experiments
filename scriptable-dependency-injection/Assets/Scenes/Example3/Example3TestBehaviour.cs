using UnityEngine;
using Gemserk;

public class Example3TestBehaviour : MonoBehaviour {

	public InterfaceReference testReference1;

	[FilterTypeProperty(filterType=typeof(IMegaSystem))]
	public InterfaceReference testReference2;

	public Example1SignalChannel testObject1;

	public InterfaceObject<string> testObject2;

}
