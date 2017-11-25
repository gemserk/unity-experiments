﻿
namespace Gemserk.Values
{
	public interface Value {

//		int GetInt();

		float GetFloat();

		T Get<T>() where T : class;

		void SetFloat(float f);

		void Set<T>(T t) where T : class;

		ValueType ValueType {
			get;
		}

	}

}
