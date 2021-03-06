﻿using UnityEngine;
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

		Assert.That (interfaceObject.Get (), Is.SameAs(interfaceImpl));
	}

	[Test]
	public void TestGetFromObject() {
		var interfaceObject = new InterfaceObject<TestInterface> ();

		var gameObject = new GameObject ();
		var interfaceImpl = gameObject.AddComponent<TestInterfaceImplementation>();
		interfaceObject._object = gameObject;

		Assert.That (interfaceObject.Get (), Is.SameAs(interfaceImpl));
	}

	[Test]
	public void TestSetInstanceOverride() {
		var interfaceObject = new InterfaceObject<TestInterface> ();

		var gameObject = new GameObject ();
		var interfaceImpl = gameObject.AddComponent<TestInterfaceImplementation>();
		interfaceObject._object = interfaceImpl;

		Assert.That (interfaceObject.Get (), Is.SameAs(interfaceImpl));
		var gameObject2 = new GameObject ();
		var otherImpl = gameObject2.AddComponent<TestInterfaceImplementation>();

		interfaceObject.Set (otherImpl);
		Assert.That (interfaceObject.Get () != null);
		Assert.That (interfaceObject.Get (), Is.SameAs(otherImpl));
		Assert.That (interfaceObject._object != null);
		Assert.That (interfaceObject._object == otherImpl);

		var otherImpl2 = new TestInterfaceImplementationNotBehaviour ();
		interfaceObject.Set (otherImpl2);
		Assert.That (interfaceObject.Get () != null);
		Assert.That (interfaceObject.Get () == otherImpl2);
		Assert.That (interfaceObject._object == null);
	}

	[Test]
	public void TestAssignableFrom() {

		var gameObject = new GameObject ();
		var testImpl = gameObject.AddComponent<TestInterfaceImplementation>();

		Assert.That(typeof(TestInterface).IsAssignableFrom(testImpl.GetType()));

//		Assert.That(testImpl.GetType().IsAssignableFrom(typeof(TestInterface)));
	}

	[Test]
	public void TestSetInstanceReferenceOverride() {
		var interfaceReference = new InterfaceReference ();

		var gameObject = new GameObject ();
		var interfaceImpl = gameObject.AddComponent<TestInterfaceImplementation>();
		interfaceReference._object = interfaceImpl;

		Assert.That (interfaceReference.Get<TestInterface> (), Is.SameAs(interfaceImpl));

		var gameObject2 = new GameObject ();
		var otherImpl = gameObject2.AddComponent<TestInterfaceImplementation>();

		interfaceReference.Set (otherImpl);
		Assert.That (interfaceReference.Get<TestInterface> () != null);
		Assert.That (interfaceReference.Get<TestInterface> (), Is.SameAs(otherImpl));
		Assert.That (interfaceReference._object != null);
		Assert.That (interfaceReference._object == otherImpl);

		var otherImpl2 = new TestInterfaceImplementationNotBehaviour ();
		interfaceReference.Set (otherImpl2);
		Assert.That (interfaceReference.Get<TestInterface> () != null);
		Assert.That (interfaceReference.Get<TestInterface> () == otherImpl2);
		Assert.That (interfaceReference._object == null);
	}
}
