using UnityEngine;
using System.Collections;
using UINamespace;

public class MainMenuRunner : MonoBehaviour
{
	public Font fontButtons;
	public Font fontTitle;

	public AudioClip hover, dehover;

	private UI m_panel;

	private UIStaticButton m_playButton;
	private UIStaticButton m_creditsButton;
	private UIStaticButton m_instructionsButton;

	private int screenWidth;
	private int screenHeight;

	private string start = "A Spire Of \n";
	private string[] end = new string[]{"Defendrs", "Baby Boomer \nDistrust of \nMillennials", "VGDevs", "Vague \nDisappointment",
		"Freaking \nNERDS", "Blood Loss", "Graphic T-shirts", "Hipster Glasses", "No Shave \nNovember", "Skinny Jeans", 
		"Christmas", "Halloween", "Thanksgiving", "Distrust of Authority", "Unexplainable Rage", "The loss of \ninnocence",
		"What the heck", "[Insert Title Here]", "Titles", "Endless Questions", "One more week", "Something Something"};
	
	void Start()
	{
		UITextInfo titleTextInfo = new UITextInfo();
		titleTextInfo.SetFont(fontTitle).SetFontSize(72).SetColor(new Color(1f, 1f, 1f)).SetTextAlignment(UIAnchorLocation.MID_TOP);

		UITextInfo buttonsTextInfo = new UITextInfo();
		buttonsTextInfo.SetFont(fontButtons).SetFontSize(36).SetColor(new Color(1f, 1f, 1f)).SetTextAlignment(UIAnchorLocation.CENTER);

		UITextInfo buttonsLargerTextInfo = new UITextInfo();
		buttonsLargerTextInfo.SetFont(fontButtons).SetFontSize(48).SetColor(new Color(1f, 1f, 1f)).SetTextAlignment(UIAnchorLocation.CENTER);

		UIRelativeLayout rootLayout = new UIRelativeLayout(0f, 0f, 1f, 1f, null, UIAnchorLocation.LEFT_BOT);

		UIStringLabel titleLabel = new UIStringLabel(0.5f, 0.7f, 1f, 0.5f, null, UILayoutType.RELATIVE_LAYOUT, UIAnchorLocation.CENTER, titleTextInfo, start + end[Random.Range (0, end.Length)]);

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

		rootLayout.AddUIComponent(titleLabel)
			.AddUIComponent(playButton)
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
