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
		private UIComponentGroupIterator m_componentGroupIterator;

		public UIMenu(UIEnum whichMenu)
		{
			switch (whichMenu)
			{
			case UIEnum.TEST_MENU1:
			{
				UIGridLayout menu1Group = new UIGridLayout(0f, 0f, 1f, 1f, null, UIAnchorLocation.LEFT_BOT, 1, 3);
				UIStringLabel menu1StringLabel1 = new UIStringLabel(0f, 0f, 1f, 0.5f, null, UILayoutType.RELATIVE_LAYOUT, UIAnchorLocation.LEFT_BOT, "BUTTON 1");
				UIStringLabel menu1StringLabel2 = new UIStringLabel(0f, 1f, 0.9f, 0.8f, null, UILayoutType.RELATIVE_LAYOUT, UIAnchorLocation.LEFT_TOP, "BUTTON 2");
//				UIButton menu1Button1 = new UIButton(0f, 0f, 1f, 0.5f, null, UILayoutType.RELATIVE_LAYOUT, UIAnchorLocation.LEFT_BOT);
//				UIButton menu1Button2 = new UIButton(0f, 1f, 0.9f, 0.8f, null, UILayoutType.RELATIVE_LAYOUT, UIAnchorLocation.LEFT_TOP);

//				ArrayList button1List = new ArrayList(1);
//				button1List.Add(UIAnchorLocation.LEFT_BOT);
//				button1List.Add(UILayoutType.RELATIVE_LAYOUT);//UILayoutType.PIXEL_LAYOUT);
//				button1List.Add(0f);
//				button1List.Add(0f);
//				button1List.Add(1f);
//				button1List.Add(0.5f);
//				button1List.Add("Button 1");
//				UIComponentFactoryData menu1Button1Data = new UIComponentFactoryData(UIComponentEnum.BUTTON, button1List);
//				ArrayList button2List = new ArrayList(1);
//				button2List.Add(UIAnchorLocation.LEFT_TOP);
//				button2List.Add(UILayoutType.RELATIVE_LAYOUT);
//				button2List.Add(0f);
//				button2List.Add(1f);
//				button2List.Add(0.9f);
//				button2List.Add(0.8f);
//				button2List.Add("Button 2");
//				UIComponentFactoryData menu1Button2Data = new UIComponentFactoryData(UIComponentEnum.BUTTON, button2List);
//				menu1Group.AddUIComponent(menu1Button1Data, 0, 0, 1, 1);
//				menu1Group.AddUIComponent(menu1Button2Data, 0, 2, 1, 1);

				menu1Group.AddUIComponent(menu1StringLabel1, 0, 0, 1, 1).AddUIComponent(menu1StringLabel2, 0, 2, 1, 1);

				m_componentGroupIterator = new UIComponentGroupIterator(menu1Group);
			}
				break;
			case UIEnum.TEST_MENU2:

				break;
			}
		}

		public void OnGUI()
		{
			m_componentGroupIterator.OnGUI();
		}
	}
}
