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

				UIRelativeLayout playButtonLayoutGroupIdle = new UIRelativeLayout("playButtonLayoutGroupIdle", 0f, 0f, 1f, 1f, null, UIAnchorLocation.LEFT_BOT);
				UIRelativeLayout playButtonLayoutGroupHighlighted = new UIRelativeLayout("playButtonLayoutGroupHighlighted", 0f, 0f, 1f, 1f, null, UIAnchorLocation.LEFT_BOT);
				UIRelativeLayout tutorialButtonLayoutGroupIdle = new UIRelativeLayout("tutorialButtonLayoutGroupIdle", 0f, 0f, 1f, 1f, null, UIAnchorLocation.LEFT_BOT);
				UIRelativeLayout tutorialButtonLayoutGroupHighlighted = new UIRelativeLayout("tutorialButtonLayoutGroupHighlighted", 0f, 0f, 1f, 1f, null, UIAnchorLocation.LEFT_BOT);
				UIRelativeLayout creditsButtonLayoutGroupIdle = new UIRelativeLayout("creditsButtonLayoutGroupIdle", 0f, 0f, 1f, 1f, null, UIAnchorLocation.LEFT_BOT);
				UIRelativeLayout creditsButtonLayoutGroupHighlighted = new UIRelativeLayout("creditsButtonLayoutGroupHighlighted", 0f, 0f, 1f, 1f, null, UIAnchorLocation.LEFT_BOT);

				UITextureLabel playButtonBorderIdle = new UITextureLabel("playButtonBorderIdle", 0.1f, 0.1f, 0.8f, 0.8f, null, UILayoutType.RELATIVE_LAYOUT, UIAnchorLocation.LEFT_BOT, buttonBorderTexture);
				UITextureLabel playButtonBorderHighlighted = new UITextureLabel(0.1f, 0.1f, 0.8f, 0.8f, null, UILayoutType.RELATIVE_LAYOUT, UIAnchorLocation.LEFT_BOT, buttonBorderTexture);
				UITextureLabel tutorialButtonBorderIdle = new UITextureLabel(0.1f, 0.1f, 0.8f, 0.8f, null, UILayoutType.RELATIVE_LAYOUT, UIAnchorLocation.LEFT_BOT, buttonBorderTexture);
				UITextureLabel tutorialButtonBorderHighlighted = new UITextureLabel(0.1f, 0.1f, 0.8f, 0.8f, null, UILayoutType.RELATIVE_LAYOUT, UIAnchorLocation.LEFT_BOT, buttonBorderTexture);
				UITextureLabel creditsButtonBorderIdle = new UITextureLabel(0.1f, 0.1f, 0.8f, 0.8f, null, UILayoutType.RELATIVE_LAYOUT, UIAnchorLocation.LEFT_BOT, buttonBorderTexture);
				UITextureLabel creditsButtonBorderHighlighted = new UITextureLabel(0.1f, 0.1f, 0.8f, 0.8f, null, UILayoutType.RELATIVE_LAYOUT, UIAnchorLocation.LEFT_BOT, buttonBorderTexture);

				UIStringLabel playButtonStringLabelIdle = new UIStringLabel(0.14f, 0f, 0.8f, 1f, null, UILayoutType.RELATIVE_LAYOUT, UIAnchorLocation.LEFT_BOT, buttonTextInfo, "Play");
				UIStringLabel playButtonStringLabelHighlighted = new UIStringLabel(0.24f, 0f, 0.8f, 1f, null, UILayoutType.RELATIVE_LAYOUT, UIAnchorLocation.LEFT_BOT, buttonTextInfo, "Play");
				UIStringLabel tutorialButtonStringLabelIdle = new UIStringLabel(0.14f, 0f, 0.8f, 1f, null, UILayoutType.RELATIVE_LAYOUT, UIAnchorLocation.LEFT_BOT, buttonTextInfo, "Tutorial");
				UIStringLabel tutorialButtonStringLabelHighlighted = new UIStringLabel(0.24f, 0f, 0.8f, 1f, null, UILayoutType.RELATIVE_LAYOUT, UIAnchorLocation.LEFT_BOT, buttonTextInfo, "Tutorial");
				UIStringLabel creditsButtonStringLabelIdle = new UIStringLabel(0.14f, 0f, 0.8f, 1f, null, UILayoutType.RELATIVE_LAYOUT, UIAnchorLocation.LEFT_BOT, buttonTextInfo, "Credits");
				UIStringLabel creditsButtonStringLabelHighlighted = new UIStringLabel(0.24f, 0f, 0.8f, 1f, null, UILayoutType.RELATIVE_LAYOUT, UIAnchorLocation.LEFT_BOT, buttonTextInfo, "Credits");

				UITextureLabel menuBackgroundLabel = new UITextureLabel(0.5f, 0.5f, 1.2f, 1.2f, null, UILayoutType.RELATIVE_LAYOUT, UIAnchorLocation.CENTER, menuBackgroundTexture);
				UITextureLabel menuLeftSideLabel = new UITextureLabel(0f, 0f, 1f, 1f, null, UILayoutType.RELATIVE_LAYOUT, UIAnchorLocation.LEFT_BOT, menuLeftSideTexture);

				playButtonLayoutGroupIdle.AddUIComponent(playButtonBorderIdle).AddUIComponent(playButtonStringLabelIdle);
				tutorialButtonLayoutGroupIdle.AddUIComponent(tutorialButtonBorderIdle).AddUIComponent(tutorialButtonStringLabelIdle);
				creditsButtonLayoutGroupIdle.AddUIComponent(creditsButtonBorderIdle).AddUIComponent(creditsButtonStringLabelIdle);

				playButtonLayoutGroupHighlighted.AddUIComponent(playButtonBorderHighlighted).AddUIComponent(playButtonStringLabelHighlighted);
				tutorialButtonLayoutGroupHighlighted.AddUIComponent(tutorialButtonBorderHighlighted).AddUIComponent(tutorialButtonStringLabelHighlighted);
				creditsButtonLayoutGroupHighlighted.AddUIComponent(creditsButtonBorderHighlighted).AddUIComponent(creditsButtonStringLabelHighlighted);

				UIStaticButton playButton = new UIStaticButton(0.1f, 0.1f, 0.8f, 0.8f, null, UILayoutType.RELATIVE_LAYOUT, UIAnchorLocation.LEFT_BOT, new PlayButtonListener());
				UIStaticButton tutorialButton = new UIStaticButton(0.1f, 0.1f, 0.8f, 0.8f, null, UILayoutType.RELATIVE_LAYOUT, UIAnchorLocation.LEFT_BOT, new TutorialButtonListener());
				UIStaticButton creditsButton = new UIStaticButton(0.1f, 0.1f, 0.8f, 0.8f, null, UILayoutType.RELATIVE_LAYOUT, UIAnchorLocation.LEFT_BOT, new CreditsButtonListener());

				playButton.SetUIComponentIdle(playButtonLayoutGroupIdle).SetUIComponentHighlighted(playButtonLayoutGroupHighlighted);
				tutorialButton.SetUIComponentIdle(tutorialButtonLayoutGroupIdle).SetUIComponentHighlighted(tutorialButtonLayoutGroupHighlighted);
				creditsButton.SetUIComponentIdle(creditsButtonLayoutGroupIdle).SetUIComponentHighlighted(creditsButtonLayoutGroupHighlighted);

				menu1Group.AddUIComponent(menuBackgroundLabel, 1, 1, 4, 3)
					.AddUIComponent(menuLeftSideLabel, 0, 0, 1, 5)
						.AddUIComponent(playButton, 1, 1, 4, 1)
						.AddUIComponent(tutorialButton, 1, 2, 4, 1)
						.AddUIComponent(creditsButton, 1, 3, 4, 1);

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

		public void CalculateRenderingOutput()
		{
			m_componentGroupIterator.CalculateRenderingOutput();
		}

		public void CheckIfInputInButton(int x, int y)
		{
			m_componentGroupIterator.CheckIfInputInButton(x, y);
		}

		public void CheckIfInputInButton(float x, float y)
		{
			m_componentGroupIterator.CheckIfInputInButton(x, y);
		}

		public bool AcknowledgeInput(int x, int y)
		{
			return m_componentGroupIterator.AcknowledgeInput(x, y);
		}
		public bool AcknowledgeInput(float x, float y)
		{
			return m_componentGroupIterator.AcknowledgeInput(x, y);
		}
	}
}
