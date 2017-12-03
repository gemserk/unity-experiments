using UnityEngine;
using NUnit.Framework;

public class ContextProviderTests {

	[Test]
	public void TestDirectlyContextProviderImpl() {

		var contextProvider = new ContextProviderImpl ();
		contextProvider.Set<object> (this);

		var instance = contextProvider.Get<object> ();

		Assert.That (instance, Is.SameAs (this));

	}

	[Test]
	public void TestUsingContextProviderAsset() {

//		var contextProvider = Create
		var contextProvider = ScriptableObject.CreateInstance<ContextProviderAsset>();
		contextProvider.Set<object> (this);

		var instance = contextProvider.Get<object> ();

		Assert.That (instance, Is.SameAs (this));

	}
		
}
