using UnityEngine;
using System.Collections;
using UINamespace;

public class LevelSelectMenuRunner : MonoBehaviour
{
	public Font fontButtons;
		
	public AudioClip hover, dehover;
	
	private UI m_panel;

	private int screenWidth;
	private int screenHeight;

	void Start()
	{
		UITextInfo buttonsTextInfo = new UITextInfo();
		buttonsTextInfo.SetFont(fontButtons).SetFontSize(36).SetColor(new Color(1f, 1f, 1f)).SetTextAlignment(UIAnchorLocation.CENTER);
		
		UITextInfo buttonsLargerTextInfo = new UITextInfo();
		buttonsLargerTextInfo.SetFont(fontButtons).SetFontSize(48).SetColor(new Color(1f, 1f, 1f)).SetTextAlignment(UIAnchorLocation.CENTER);
		
		UIRelativeLayout rootLayout = new UIRelativeLayout(0f, 0f, 1f, 1f, null, UIAnchorLocation.LEFT_BOT);

		UIStringLabel playLabelSmall = 			new UIStringLabel(0.5f, 0.3f, 0.8f, 0.2f, null, UILayoutType.RELATIVE_LAYOUT, UIAnchorLocation.CENTER, buttonsTextInfo, "Play");
		UIStringLabel creditsLabelSmall = 		new UIStringLabel(0.5f, 0.2f, 0.8f, 0.2f, null, UILayoutType.RELATIVE_LAYOUT, UIAnchorLocation.CENTER, buttonsTextInfo, "Credits");
		UIStringLabel instructionsLabelSmall = 	new UIStringLabel(0.5f, 0.1f, 0.8f, 0.2f, null, UILayoutType.RELATIVE_LAYOUT, UIAnchorLocation.CENTER, buttonsTextInfo, "Instructions");
		
		UIStringLabel playLabelLarge = 			new UIStringLabel(0.5f, 0.3f, 0.8f, 0.2f, null, UILayoutType.RELATIVE_LAYOUT, UIAnchorLocation.CENTER, buttonsLargerTextInfo, "Play");
		UIStringLabel creditsLabelLarge = 		new UIStringLabel(0.5f, 0.2f, 0.8f, 0.2f, null, UILayoutType.RELATIVE_LAYOUT, UIAnchorLocation.CENTER, buttonsLargerTextInfo, "Credits");
		UIStringLabel instructionsLabelLarge = 	new UIStringLabel(0.5f, 0.1f, 0.8f, 0.2f, null, UILayoutType.RELATIVE_LAYOUT, UIAnchorLocation.CENTER, buttonsLargerTextInfo, "Instructions");
		
		UIStaticButton playButton = 		new UIStaticButton(0.5f, 0.3f, 0.8f, 0.1f, null, UILayoutType.RELATIVE_LAYOUT, UIAnchorLocation.CENTER, new MenuButtonListener(hover, dehover, "Levels"));
		UIStaticButton creditsButton = 		new UIStaticButton(0.5f, 0.2f, 0.8f, 0.1f, null, UILayoutType.RELATIVE_LAYOUT, UIAnchorLocation.CENTER, new MenuButtonListener(hover, dehover, "Credits"));
		UIStaticButton instructionsButton = new UIStaticButton(0.5f, 0.1f, 0.8f, 0.1f, null, UILayoutType.RELATIVE_LAYOUT, UIAnchorLocation.CENTER, new MenuButtonListener(hover, dehover, "Instructions"));
		
		playButton.			SetUIComponentIdle(playLabelSmall).			SetUIComponentHighlighted(playLabelLarge);
		creditsButton.		SetUIComponentIdle(creditsLabelSmall).		SetUIComponentHighlighted(creditsLabelLarge);
		instructionsButton.	SetUIComponentIdle(instructionsLabelSmall).	SetUIComponentHighlighted(instructionsLabelLarge);
		
		playButton.SetStartStateIdle();
		creditsButton.SetStartStateIdle();
		instructionsButton.SetStartStateIdle();
		
		rootLayout.AddUIComponent(playButton)
				.AddUIComponent(creditsButton)
				.AddUIComponent(instructionsButton);
		
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
