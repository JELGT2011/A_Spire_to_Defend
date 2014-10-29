using UnityEngine;
using System.Collections;
using UINamespace;

public class GUIRunner : MonoBehaviour
{
	public Font font;
	public Texture2D[] towerPictures;

	public AudioClip hover, dehover;

	private UI m_panel;
	
	private int screenWidth;
	private int screenHeight;
	
	public void Setup()
	{
		UITextInfo backTextInfo = new UITextInfo();
		backTextInfo.SetFont(font).SetFontSize(24).SetColor(new Color(0f, 0f, 0f)).SetTextAlignment(UIAnchorLocation.LEFT_TOP);
		UITextInfo backTextLargerInfo = new UITextInfo();
		backTextLargerInfo.SetFont(font).SetFontSize(28).SetColor(new Color(0f, 0f, 0f)).SetTextAlignment(UIAnchorLocation.LEFT_TOP);

		UITextInfo healthTextInfo = new UITextInfo();
		healthTextInfo.SetFont(font).SetFontSize(48).SetColor(new Color(1f, 0f, 0f)).SetTextAlignment(UIAnchorLocation.RIGHT_MID);
		UITextInfo resourcesTextInfo = new UITextInfo();
		resourcesTextInfo.SetFont(font).SetFontSize(48).SetColor(new Color(0f, 0f, 0f)).SetTextAlignment(UIAnchorLocation.RIGHT_MID);
		UITextInfo resourcesNumberTextInfo = new UITextInfo();
		resourcesNumberTextInfo.SetFont(font).SetFontSize(48).SetColor(new Color(0f, 0f, 0f)).SetTextAlignment(UIAnchorLocation.CENTER);
		UITextInfo healthNumberTextInfo = new UITextInfo();
		healthNumberTextInfo.SetFont(font).SetFontSize(48).SetColor(new Color(1f, 0f, 0f)).SetTextAlignment(UIAnchorLocation.CENTER);

		UITextInfo everythingElseTextInfo = new UITextInfo();
		healthTextInfo.SetFont(font).SetFontSize(32).SetColor(new Color(0f, 0f, 0f)).SetTextAlignment(UIAnchorLocation.LEFT_TOP);
		
		UIRelativeLayout rootLayout = new UIRelativeLayout("rootLayout", 0f, 0f, 1f, 1f, null, UIAnchorLocation.LEFT_BOT);
		
		UIStringLabel backLabelSmall = new UIStringLabel(0.01f, 0.99f, 0.2f, 0.1f, null, UILayoutType.RELATIVE_LAYOUT, UIAnchorLocation.LEFT_TOP, backTextInfo, "Back");
		UIStringLabel backLabelLarge = new UIStringLabel(0.01f, 0.99f, 0.2f, 0.1f, null, UILayoutType.RELATIVE_LAYOUT, UIAnchorLocation.LEFT_TOP, backTextLargerInfo, "Back");
		UIStaticButton backButton = new UIStaticButton(0.01f, 0.99f, 0.1f, 0.08f, null, UILayoutType.RELATIVE_LAYOUT, UIAnchorLocation.LEFT_TOP, new MenuButtonListener(hover, dehover, "MainMenu"));
		
		backButton.SetUIComponentIdle(backLabelSmall).SetUIComponentHighlighted(backLabelLarge);
		
		rootLayout.AddUIComponent(backButton);
		
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
