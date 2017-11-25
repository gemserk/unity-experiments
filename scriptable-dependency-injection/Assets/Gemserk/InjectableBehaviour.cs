using UnityEngine;

public class InjectableBehaviour : MonoBehaviour
{
	public InjectorAsset injector;

	void Awake() {
		injector.Inject (this);
	}
}