using UnityEngine;
using System.Collections;
using UINamespace;

public class LevelSelectMenuRunner : MonoBehaviour
{
	public Font fontLevels;
	public Font fontBack;
		
	public AudioClip hover, dehover;

	public string[] levelNames;
	
	public Texture2D levelBorderTexture;
	
	private UI m_panel;

	private int screenWidth;
	private int screenHeight;

	void Start()
	{
		UITextInfo buttonsTextInfo = new UITextInfo();
		buttonsTextInfo.SetFont(fontLevels).SetFontSize(64).SetColor(new Color(1f, 1f, 1f)).SetTextAlignment(UIAnchorLocation.CENTER);
		
		UITextInfo buttonsLargerTextInfo = new UITextInfo();
		buttonsLargerTextInfo.SetFont(fontLevels).SetFontSize(72).SetColor(new Color(1f, 1f, 1f)).SetTextAlignment(UIAnchorLocation.CENTER);

		UITextInfo backTextInfo = new UITextInfo();
		backTextInfo.SetFont(fontBack).SetFontSize(24).SetColor(new Color(1f, 1f, 1f)).SetTextAlignment(UIAnchorLocation.LEFT_TOP);

		UITextInfo backTextLargerInfo = new UITextInfo();
		backTextLargerInfo.SetFont(fontBack).SetFontSize(28).SetColor(new Color(1f, 1f, 1f)).SetTextAlignment(UIAnchorLocation.LEFT_TOP);
		
		UIRelativeLayout rootLayout = new UIRelativeLayout("rootLayout", 0f, 0f, 1f, 1f, null, UIAnchorLocation.LEFT_BOT);

		UIStringLabel backLabelSmall = new UIStringLabel(0.01f, 0.99f, 0.2f, 0.1f, null, UILayoutType.RELATIVE_LAYOUT, UIAnchorLocation.LEFT_TOP, backTextInfo, "Back");
		UIStringLabel backLabelLarge = new UIStringLabel(0.01f, 0.99f, 0.2f, 0.1f, null, UILayoutType.RELATIVE_LAYOUT, UIAnchorLocation.LEFT_TOP, backTextLargerInfo, "Back");
		UIStaticButton backButton = new UIStaticButton(0.01f, 0.99f, 0.1f, 0.08f, null, UILayoutType.RELATIVE_LAYOUT, UIAnchorLocation.LEFT_TOP, new MenuButtonListener(hover, dehover, "MainMenu"));

		backButton.SetUIComponentIdle(backLabelSmall).SetUIComponentHighlighted(backLabelLarge);

		rootLayout.AddUIComponent(backButton);

		UIGridLayout gridLayout = new UIGridLayout("GridLayout", 0.5f, 0.5f, 0.85f, 0.8f, null, UIAnchorLocation.CENTER, 2, 3);

		for (int n = 0; n < levelNames.Length; ++n)
		{
			UIRelativeLayout highlightedLayout = new UIRelativeLayout(0.015f, 0.05f, 0.97f, 0.90f, null, UIAnchorLocation.LEFT_BOT);

			highlightedLayout.AddUIComponent(new UITextureLabel(0f, 0f, 1f, 1f, null, UILayoutType.RELATIVE_LAYOUT, UIAnchorLocation.LEFT_BOT, levelBorderTexture))
				.AddUIComponent(new UIStringLabel(0f, 0f, 1f, 1f, null, UILayoutType.RELATIVE_LAYOUT, UIAnchorLocation.LEFT_BOT, buttonsLargerTextInfo, "Level " + (n+1)));

			UIRelativeLayout notHighlightedLayout = new UIRelativeLayout(0.015f, 0.05f, 0.97f, 0.90f, null, UIAnchorLocation.LEFT_BOT);

			notHighlightedLayout.AddUIComponent(new UITextureLabel("Level" + (n+1) + "relativeLayout", 0f, 0f, 1f, 1f, null, UILayoutType.RELATIVE_LAYOUT, UIAnchorLocation.LEFT_BOT, levelBorderTexture))
				.AddUIComponent(new UIStringLabel(0f, 0f, 1f, 1f, null, UILayoutType.RELATIVE_LAYOUT, UIAnchorLocation.LEFT_BOT, buttonsTextInfo, "Level " + (n+1)));

			UIStaticButton levelButton = new UIStaticButton(0.015f, 0.05f, 0.97f, 0.90f, null, UILayoutType.RELATIVE_LAYOUT, UIAnchorLocation.LEFT_BOT, new MenuButtonListener(hover, dehover, levelNames[n]));

			levelButton.SetUIComponentIdle(notHighlightedLayout).SetUIComponentHighlighted(highlightedLayout);

			gridLayout.AddUIComponent(levelButton, n % 2, n / 2, 1, 1);
		}

		rootLayout.AddUIComponent(gridLayout);
		
		m_panel = new UI(rootLayout);
		m_panel.SetStartMenu(1);
		
		screenWidth = Screen.width;
		screenHeight = Screen.height;
	}
	
	void OnGUI()
	{
		m_panel.OnGUI();
	}
	
	void Update()
	{
		m_panel.CheckIfInputInButton((int)Input.mousePosition.x, (int)Input.mousePosition.y);
		
		if (Input.GetMouseButtonDown(0))
		{
			m_panel.AcknowledgeInput((int)Input.mousePosition.x, (int)Input.mousePosition.y);
		}
		if (screenWidth != Screen.width || screenHeight != Screen.height)
		{
			screenWidth = Screen.width;
			screenHeight = Screen.height;
			m_panel.CalculateRenderingOutput();
		}
	}
}
