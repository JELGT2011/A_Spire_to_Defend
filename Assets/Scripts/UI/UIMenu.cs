using UnityEngine;
using System.Collections;

namespace UINamespace
{
	/// <summary>
	/// Menus are screens to be on the screen either at the same time or on top of each other.
	/// They work like Activities in Android, kind of.
	/// </summary>
	public class UIMenu
	{
		private UIComponentGroupTree m_componentGroupTree;

		public UIMenu(UIEnum whichMenu)
		{
			switch (whichMenu)
			{
			case UIEnum.TEST_MENU1:
			{
				UIGridLayout menu1Group = new UIGridLayout(0f, 0f, 1f, 1f, null, 1, 3);
				UIButton menu1Button1 = new UIButton("BUTTON 1");
				UIButton menu1Button2 = new UIButton("BUTTON 2");
				menu1Group.AddUIComponent(menu1Button1, 0, 0, 1, 1);
				menu1Group.AddUIComponent(menu1Button2, 0, 2, 1, 1);
			}
				break;
			case UIEnum.TEST_MENU2:

				break;
			}
		}
	}
}
