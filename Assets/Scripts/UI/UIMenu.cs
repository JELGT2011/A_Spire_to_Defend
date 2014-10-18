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

		public UIMenu(UIEnum whichMenu, Font font)
		{
			switch (whichMenu)
			{
			case UIEnum.TEST_MENU1:
			{
				UIGridLayout menu1Group = new UIGridLayout(0f, 0f, 1f, 1f, null, UIAnchorLocation.LEFT_BOT, 6, 5);

				UITextInfo buttonTextInfo = new UITextInfo();
				buttonTextInfo.SetFontSize(48).SetFontStyle(UIFontStyle.BOLD).SetColor(new Color(1f, 1f, 1f)).SetFont(font).SetTextAlignment(UIAnchorLocation.LEFT_MID);

				Texture2D menuBackgroundTexture = Resources.Load<Texture2D>("UITextures/MidBackground");
				Texture2D menuLeftSideTexture = Resources.Load<Texture2D>("UITextures/LeftSideThing");
				Texture2D buttonBorderTexture = Resources.Load<Texture2D>("UITextures/ButtonBorder");

				UIRelativeLayout playButtonLayoutGroup = new UIRelativeLayout(0f, 0f, 1f, 1f, null, UIAnchorLocation.LEFT_BOT);
				UIRelativeLayout tutorialButtonLayoutGroup = new UIRelativeLayout(0f, 0f, 1f, 1f, null, UIAnchorLocation.LEFT_BOT);
				UIRelativeLayout creditsButtonLayoutGroup = new UIRelativeLayout(0f, 0f, 1f, 1f, null, UIAnchorLocation.LEFT_BOT);

				UITextureLabel playButtonBorder = new UITextureLabel(0.1f, 0.1f, 0.8f, 0.8f, null, UILayoutType.RELATIVE_LAYOUT, UIAnchorLocation.LEFT_BOT, buttonBorderTexture);
				UITextureLabel tutorialButtonBorder = new UITextureLabel(0.1f, 0.1f, 0.8f, 0.8f, null, UILayoutType.RELATIVE_LAYOUT, UIAnchorLocation.LEFT_BOT, buttonBorderTexture);
				UITextureLabel creditsButtonBorder = new UITextureLabel(0.1f, 0.1f, 0.8f, 0.8f, null, UILayoutType.RELATIVE_LAYOUT, UIAnchorLocation.LEFT_BOT, buttonBorderTexture);

				UIStringLabel playButtonStringLabel = new UIStringLabel(0.2f, 0f, 0.8f, 1f, null, UILayoutType.RELATIVE_LAYOUT, UIAnchorLocation.LEFT_BOT, buttonTextInfo, "Play");
				UIStringLabel tutorialButtonStringLabel = new UIStringLabel(0.2f, 0f, 0.8f, 1f, null, UILayoutType.RELATIVE_LAYOUT, UIAnchorLocation.LEFT_BOT, buttonTextInfo, "Tutorial");
				UIStringLabel creditsButtonStringLabel = new UIStringLabel(0.2f, 0f, 0.8f, 1f, null, UILayoutType.RELATIVE_LAYOUT, UIAnchorLocation.LEFT_BOT, buttonTextInfo, "Credits");

				UITextureLabel menuBackgroundLabel = new UITextureLabel(0.5f, 0.5f, 1.2f, 1.2f, null, UILayoutType.RELATIVE_LAYOUT, UIAnchorLocation.CENTER, menuBackgroundTexture);
				UITextureLabel menuLeftSideLabel = new UITextureLabel(0f, 0f, 1f, 1f, null, UILayoutType.RELATIVE_LAYOUT, UIAnchorLocation.LEFT_BOT, menuLeftSideTexture);

				playButtonLayoutGroup.AddUIComponent(playButtonBorder).AddUIComponent(playButtonStringLabel);
				tutorialButtonLayoutGroup.AddUIComponent(tutorialButtonBorder).AddUIComponent(tutorialButtonStringLabel);
				creditsButtonLayoutGroup.AddUIComponent(creditsButtonBorder).AddUIComponent(creditsButtonStringLabel);

//				UIButton menu1Button1 = new UIButton(0f, 0f, 1f, 0.5f, null, UILayoutType.RELATIVE_LAYOUT, UIAnchorLocation.LEFT_BOT);
//				UIButton menu1Button2 = new UIButton(0f, 1f, 0.9f, 0.8f, null, UILayoutType.RELATIVE_LAYOUT, UIAnchorLocation.LEFT_TOP);

				menu1Group.AddUIComponent(menuBackgroundLabel, 1, 1, 4, 3)
					.AddUIComponent(menuLeftSideLabel, 0, 0, 1, 5)
						.AddUIComponent(playButtonLayoutGroup, 1, 1, 4, 1)
						.AddUIComponent(tutorialButtonLayoutGroup, 1, 2, 4, 1)
						.AddUIComponent(creditsButtonLayoutGroup, 1, 3, 4, 1);

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
