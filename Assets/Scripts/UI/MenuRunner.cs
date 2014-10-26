using UnityEngine;
using System.Collections;
using UINamespace;

/// <summary>
/// Just some class to run the menu with the UI class
/// </summary>
public class MenuRunner : MonoBehaviour
{
	public Font m_font;
	public Camera m_camera;
	private UI m_ui;

	private int screenWidth;
	private int screenHeight;

	public GUIStyle guiStyle;

	private UIGridLayout menu1Group;
	
	private UITextInfo buttonTextInfo;
	
	public Texture2D menuBackgroundTexture;
	public Texture2D menuLeftSideTexture;
	public Texture2D buttonBorderTexture;
	
	private UIRelativeLayout playButtonLayoutGroupIdle;
	private UIRelativeLayout playButtonLayoutGroupHighlighted;
	private UIRelativeLayout tutorialButtonLayoutGroupIdle;
	private UIRelativeLayout tutorialButtonLayoutGroupHighlighted;
	private UIRelativeLayout creditsButtonLayoutGroupIdle;
	private UIRelativeLayout creditsButtonLayoutGroupHighlighted;
	
	private UITextureLabel playButtonBorderIdle;
	private UITextureLabel playButtonBorderHighlighted;
	private UITextureLabel tutorialButtonBorderIdle;
	private UITextureLabel tutorialButtonBorderHighlighted;
	private UITextureLabel creditsButtonBorderIdle;
	private UITextureLabel creditsButtonBorderHighlighted;
	
	private UIStringLabel playButtonStringLabelIdle;
	private UIStringLabel playButtonStringLabelHighlighted;
	private UIStringLabel tutorialButtonStringLabelIdle;
	private UIStringLabel tutorialButtonStringLabelHighlighted;
	private UIStringLabel creditsButtonStringLabelIdle;
	private UIStringLabel creditsButtonStringLabelHighlighted;
	
	private UITextureLabel menuBackgroundLabel;
	private UITextureLabel menuLeftSideLabel;
	
	private UIStaticButton playButton;
	private UIStaticButton tutorialButton;
	private UIStaticButton creditsButton;


	void Start()
	{
		menu1Group = new UIGridLayout(0f, 0f, 1f, 1f, null, UIAnchorLocation.LEFT_BOT, 6, 5);

		buttonTextInfo = new UITextInfo();
		buttonTextInfo.SetFontSize(48).SetFontStyle(UIFontStyle.BOLD).SetColor(new Color(1f, 1f, 1f)).SetFont(m_font).SetTextAlignment(UIAnchorLocation.LEFT_MID);
		
//		Texture2D menuBackgroundTexture = Resources.Load<Texture2D>("UITextures/MidBackground");
//		Texture2D menuLeftSideTexture = Resources.Load<Texture2D>("UITextures/LeftSideThing");
//		Texture2D buttonBorderTexture = Resources.Load<Texture2D>("UITextures/ButtonBorder");
		
		playButtonLayoutGroupIdle = new UIRelativeLayout(0f, 0f, 1f, 1f, null, UIAnchorLocation.LEFT_BOT);
		playButtonLayoutGroupHighlighted = new UIRelativeLayout(0f, 0f, 1f, 1f, null, UIAnchorLocation.LEFT_BOT);
		tutorialButtonLayoutGroupIdle = new UIRelativeLayout(0f, 0f, 1f, 1f, null, UIAnchorLocation.LEFT_BOT);
		tutorialButtonLayoutGroupHighlighted = new UIRelativeLayout(0f, 0f, 1f, 1f, null, UIAnchorLocation.LEFT_BOT);
		creditsButtonLayoutGroupIdle = new UIRelativeLayout(0f, 0f, 1f, 1f, null, UIAnchorLocation.LEFT_BOT);
		creditsButtonLayoutGroupHighlighted = new UIRelativeLayout(0f, 0f, 1f, 1f, null, UIAnchorLocation.LEFT_BOT);
		
		playButtonBorderIdle = new UITextureLabel(0.1f, 0.1f, 0.8f, 0.8f, null, UILayoutType.RELATIVE_LAYOUT, UIAnchorLocation.LEFT_BOT, buttonBorderTexture);
		playButtonBorderHighlighted = new UITextureLabel(0.1f, 0.1f, 0.8f, 0.8f, null, UILayoutType.RELATIVE_LAYOUT, UIAnchorLocation.LEFT_BOT, buttonBorderTexture);
		tutorialButtonBorderIdle = new UITextureLabel(0.1f, 0.1f, 0.8f, 0.8f, null, UILayoutType.RELATIVE_LAYOUT, UIAnchorLocation.LEFT_BOT, buttonBorderTexture);
		tutorialButtonBorderHighlighted = new UITextureLabel(0.1f, 0.1f, 0.8f, 0.8f, null, UILayoutType.RELATIVE_LAYOUT, UIAnchorLocation.LEFT_BOT, buttonBorderTexture);
		creditsButtonBorderIdle = new UITextureLabel(0.1f, 0.1f, 0.8f, 0.8f, null, UILayoutType.RELATIVE_LAYOUT, UIAnchorLocation.LEFT_BOT, buttonBorderTexture);
		creditsButtonBorderHighlighted = new UITextureLabel(0.1f, 0.1f, 0.8f, 0.8f, null, UILayoutType.RELATIVE_LAYOUT, UIAnchorLocation.LEFT_BOT, buttonBorderTexture);
		
		playButtonStringLabelIdle = new UIStringLabel(0.14f, 0f, 0.8f, 1f, null, UILayoutType.RELATIVE_LAYOUT, UIAnchorLocation.LEFT_BOT, buttonTextInfo, "Play");
		playButtonStringLabelHighlighted = new UIStringLabel(0.24f, 0f, 0.8f, 1f, null, UILayoutType.RELATIVE_LAYOUT, UIAnchorLocation.LEFT_BOT, buttonTextInfo, "Play");
		tutorialButtonStringLabelIdle = new UIStringLabel(0.14f, 0f, 0.8f, 1f, null, UILayoutType.RELATIVE_LAYOUT, UIAnchorLocation.LEFT_BOT, buttonTextInfo, "Tutorial");
		tutorialButtonStringLabelHighlighted = new UIStringLabel(0.24f, 0f, 0.8f, 1f, null, UILayoutType.RELATIVE_LAYOUT, UIAnchorLocation.LEFT_BOT, buttonTextInfo, "Tutorial");
		creditsButtonStringLabelIdle = new UIStringLabel(0.14f, 0f, 0.8f, 1f, null, UILayoutType.RELATIVE_LAYOUT, UIAnchorLocation.LEFT_BOT, buttonTextInfo, "Credits");
		creditsButtonStringLabelHighlighted = new UIStringLabel(0.24f, 0f, 0.8f, 1f, null, UILayoutType.RELATIVE_LAYOUT, UIAnchorLocation.LEFT_BOT, buttonTextInfo, "Credits");
		
		menuBackgroundLabel = new UITextureLabel(0.5f, 0.5f, 1.2f, 1.2f, null, UILayoutType.RELATIVE_LAYOUT, UIAnchorLocation.CENTER, menuBackgroundTexture);
		menuLeftSideLabel = new UITextureLabel(0f, 0f, 1f, 1f, null, UILayoutType.RELATIVE_LAYOUT, UIAnchorLocation.LEFT_BOT, menuLeftSideTexture);
		
		playButtonLayoutGroupIdle.AddUIComponent(playButtonBorderIdle).AddUIComponent(playButtonStringLabelIdle);
		tutorialButtonLayoutGroupIdle.AddUIComponent(tutorialButtonBorderIdle).AddUIComponent(tutorialButtonStringLabelIdle);
		creditsButtonLayoutGroupIdle.AddUIComponent(creditsButtonBorderIdle).AddUIComponent(creditsButtonStringLabelIdle);
		
		playButtonLayoutGroupHighlighted.AddUIComponent(playButtonBorderHighlighted).AddUIComponent(playButtonStringLabelHighlighted);
		tutorialButtonLayoutGroupHighlighted.AddUIComponent(tutorialButtonBorderHighlighted).AddUIComponent(tutorialButtonStringLabelHighlighted);
		creditsButtonLayoutGroupHighlighted.AddUIComponent(creditsButtonBorderHighlighted).AddUIComponent(creditsButtonStringLabelHighlighted);
		
		playButton = new UIStaticButton(0.1f, 0.1f, 0.8f, 0.8f, null, UILayoutType.RELATIVE_LAYOUT, UIAnchorLocation.LEFT_BOT, new PlayButtonListener());
		tutorialButton = new UIStaticButton(0.1f, 0.1f, 0.8f, 0.8f, null, UILayoutType.RELATIVE_LAYOUT, UIAnchorLocation.LEFT_BOT, new TutorialButtonListener());
		creditsButton = new UIStaticButton(0.1f, 0.1f, 0.8f, 0.8f, null, UILayoutType.RELATIVE_LAYOUT, UIAnchorLocation.LEFT_BOT, new CreditsButtonListener());

		playButton.SetUIComponentIdle(playButtonLayoutGroupIdle).SetUIComponentHighlighted(playButtonLayoutGroupHighlighted);
		tutorialButton.SetUIComponentIdle(tutorialButtonLayoutGroupIdle).SetUIComponentHighlighted(tutorialButtonLayoutGroupHighlighted);
		creditsButton.SetUIComponentIdle(creditsButtonLayoutGroupIdle).SetUIComponentHighlighted(creditsButtonLayoutGroupHighlighted);
		
		menu1Group.AddUIComponent(menuBackgroundLabel, 1, 1, 4, 3)
			.AddUIComponent(menuLeftSideLabel, 0, 0, 1, 5)
				.AddUIComponent(playButton, 1, 1, 4, 1)
				.AddUIComponent(tutorialButton, 1, 2, 4, 1)
				.AddUIComponent(creditsButton, 1, 3, 4, 1);

		m_ui = new UI(menu1Group);
		m_ui.SetStartMenu(1);

		screenWidth = Screen.width;
		screenHeight = Screen.height;
	}

	void OnGUI()
	{
		m_ui.OnGUI();
	}

	void Update()
	{
		m_ui.UpdateDeltaTime(Time.deltaTime);

		m_ui.CheckIfInputInButton((int)Input.mousePosition.x, (int)Input.mousePosition.y);

//		Debug.Break();

		if (Input.GetMouseButtonDown(0))
		{
			m_ui.AcknowledgeInput((int)Input.mousePosition.x, (int)Input.mousePosition.y);
//			Debug.Break();
		}
		if (screenWidth != Screen.width || screenHeight != Screen.height)
		{
			screenWidth = Screen.width;
			screenHeight = Screen.height;
			m_ui.CalculateRenderingOutput();
		}
	}
}
