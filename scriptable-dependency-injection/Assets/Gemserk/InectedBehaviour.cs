using UnityEngine;

public class InectedBehaviour : MonoBehaviour
{
	public InjectorAsset injector;

	void Awake() {
		injector.Inject (this);
	}
}