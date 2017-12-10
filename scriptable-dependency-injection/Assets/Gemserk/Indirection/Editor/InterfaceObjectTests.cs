using UnityEngine;
using NUnit.Framework;
using Gemserk;

public class InterfaceObjectTests {

	interface TestInterface {
		
	}

	class TestInterfaceImplementation : MonoBehaviour, TestInterface {
		
	}

	class TestInterfaceImplementationNotBehaviour : TestInterface
	{
		
	}

	[Test]
	public void TestGetFromBehaviour() {
		var interfaceObject = new InterfaceObject<TestInterface> ();

		Assert.That (interfaceObject.Get () == null);

		var gameObject = new GameObject ();
		var interfaceImpl = gameObject.AddComponent<TestInterfaceImplementation>();
		interfaceObject._object = interfaceImpl;

		Assert.That (interfaceObject.Get () == interfaceImpl);
	}

	[Test]
	public void TestGetFromObject() {
		var interfaceObject = new InterfaceObject<TestInterface> ();

		var gameObject = new GameObject ();
		var interfaceImpl = gameObject.AddComponent<TestInterfaceImplementation>();
		interfaceObject._object = gameObject;

		Assert.That (interfaceObject.Get () == interfaceImpl);
	}

	[Test]
	public void TestSetInstanceOverride() {
		var interfaceObject = new InterfaceObject<TestInterface> ();

		var gameObject = new GameObject ();
		var interfaceImpl = gameObject.AddComponent<TestInterfaceImplementation>();
		interfaceObject._object = interfaceImpl;

		Assert.That (interfaceObject.Get () == interfaceImpl);
		var gameObject2 = new GameObject ();
		var otherImpl = gameObject2.AddComponent<TestInterfaceImplementation>();

		interfaceObject.Set (otherImpl);
		Assert.That (interfaceObject.Get () != null);
		Assert.That (interfaceObject.Get () == otherImpl);
		Assert.That (interfaceObject._object != null);
		Assert.That (interfaceObject._object == otherImpl);

		var otherImpl2 = new TestInterfaceImplementationNotBehaviour ();
		interfaceObject.Set (otherImpl2);
		Assert.That (interfaceObject.Get () != null);
		Assert.That (interfaceObject.Get () == otherImpl2);
		Assert.That (interfaceObject._object == null);

	}

}
