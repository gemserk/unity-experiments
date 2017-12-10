using UnityEngine;
using System;

namespace Gemserk
{
	public class FilterTypeProperty : PropertyAttribute
	{
		public Type filterType;

		public FilterTypeProperty()
		{
		}

		public FilterTypeProperty(Type filterType)
		{
			this.filterType = filterType;
		}
	}

}