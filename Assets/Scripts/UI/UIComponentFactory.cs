using UnityEngine;
using System.Collections;

namespace UINamespace
{
	public enum UIComponentEnum
	{
		BUTTON
	};

	public class UIComponentFactory
	{
		private UIComponentFactory()
		{
			// do nothing
		}

		public static UIComponent CreateUIComponent(UIComponentFactoryData componentFactoryData, UIComponentGroup parentComponentGroup)
		{
			switch (componentFactoryData.componentEnum)
			{
			case UIComponentEnum.BUTTON:
			{
				IList dataList = componentFactoryData.componentData;
				UIAnchorLocation anchorLocation = (UIAnchorLocation)(dataList[0]);
				UILayoutType layoutType = (UILayoutType)(dataList[1]);
				string text = dataList[6] as string;
				if (UILayoutType.RELATIVE_LAYOUT == layoutType)
				{
					float xStart = (float)(dataList[2]);
					float yStart = (float)(dataList[3]);
					float xWidth = (float)(dataList[4]);
					float yHeight = (float)(dataList[5]);
					return new UIButton(xStart, yStart, xWidth, yHeight, parentComponentGroup, layoutType, anchorLocation, text);
				}
				else if (UILayoutType.PIXEL_LAYOUT == layoutType)
				{
					int xStart = (int)(dataList[2]);
					int yStart = (int)(dataList[3]);
					int xWidth = (int)(dataList[4]);
					int yHeight = (int)(dataList[5]);
					return new UIButton(xStart, yStart, xWidth, yHeight, parentComponentGroup, layoutType, anchorLocation, text);
				}
				return null;
			}
			default:
				return null;
			}
		}
	}
}
