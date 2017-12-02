using UnityEngine;
using UnityEngine.SceneManagement;

public interface TestContextInterface
{
	string GetValue();
}

public class TestScriptableDelegate : MonoBehaviour, TestContextInterface {

	[SerializeField]
	ContextProviderAsset _contextProvider;

	#region TestContextInterface implementation

	public string GetValue ()
	{
		return "Super value";
	}

	#endregion

	void Awake()
	{
		_contextProvider.Set<TestContextInterface> (this);
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	// 	Debug.Log (_contextProvider.Get<TestContextInterface> ().GetValue ());

		if (Input.GetMouseButtonUp(1)) {
			SceneManager.LoadScene (SceneManager.GetActiveScene ().name);
		}
	}
}
