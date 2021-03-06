using UnityEngine;
using System.Collections;

namespace UINamespace
{
	public sealed class UIComponentFactoryData
	{
		public UIComponentEnum componentEnum;
		public IList componentData;
		public UIComponentFactoryData(UIComponentEnum componentEnum, IList componentData)
		{
			this.componentEnum = componentEnum;
			this.componentData = componentData;
		}
	}
}