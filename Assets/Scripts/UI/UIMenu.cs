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
				UITextInfo button1TextInfo = new UITextInfo();
				button1TextInfo.SetFontSize(48).SetFontStyle(UIFontStyle.NORMAL).SetColor(new Color(0.4f, 0.5f, 0.6f));
				UITextInfo button2TextInfo = new UITextInfo();
				button2TextInfo.SetFontSize(48).SetFontStyle(UIFontStyle.BOLD).SetColor(new Color(0f, 0f, 0f));
				UIStringLabel menu1StringLabel1 = new UIStringLabel(0f, 0f, 1f, 0.5f, null, UILayoutType.RELATIVE_LAYOUT, UIAnchorLocation.LEFT_BOT, button1TextInfo, "BUTTON 1");
				UIStringLabel menu1StringLabel2 = new UIStringLabel(0f, 1f, 0.9f, 0.8f, null, UILayoutType.RELATIVE_LAYOUT, UIAnchorLocation.LEFT_TOP, button2TextInfo, "BUTTON 2");
				Texture2D texture1 = Resources.Load<Texture2D>("UITextures/TestPicture2");
				UITextureLabel menu1TextureLabel1 = new UITextureLabel(0f, 0f, 1f, 0.5f, null, UILayoutType.RELATIVE_LAYOUT, UIAnchorLocation.LEFT_BOT, texture1);
//				UITextureLabel menu1TextureLabel2 = new UITextureLabel(0f, 1f, 0.9f, 0.8f, null, UILayoutType.RELATIVE_LAYOUT, UIAnchorLocation.LEFT_TOP, null);
//				UIButton menu1Button1 = new UIButton(0f, 0f, 1f, 0.5f, null, UILayoutType.RELATIVE_LAYOUT, UIAnchorLocation.LEFT_BOT);
//				UIButton menu1Button2 = new UIButton(0f, 1f, 0.9f, 0.8f, null, UILayoutType.RELATIVE_LAYOUT, UIAnchorLocation.LEFT_TOP);

//				menu1Group.AddUIComponent(menu1StringLabel1, 0, 0, 1, 1).AddUIComponent(menu1StringLabel2, 0, 2, 1, 1);
				menu1Group.AddUIComponent(menu1TextureLabel1, 0, 0, 1, 1).AddUIComponent(menu1StringLabel2, 0, 2, 1, 1);

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
