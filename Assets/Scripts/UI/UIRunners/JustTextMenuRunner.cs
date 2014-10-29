using UnityEngine;
using System.Collections;
using UINamespace;

public class JustTextMenuRunner : MonoBehaviour
{
	public Font fontMain;
	public Font fontBack;
	
	public AudioClip hover, dehover;
	
	public string mainText;
	
	private UI m_panel;
	
	private int screenWidth;
	private int screenHeight;

	void Start()
	{
		UITextInfo backTextInfo = new UITextInfo();
		backTextInfo.SetFont(fontBack).SetFontSize(24).SetColor(new Color(1f, 1f, 1f)).SetTextAlignment(UIAnchorLocation.LEFT_TOP);
		
		UITextInfo backTextLargerInfo = new UITextInfo();
		backTextLargerInfo.SetFont(fontBack).SetFontSize(28).SetColor(new Color(1f, 1f, 1f)).SetTextAlignment(UIAnchorLocation.LEFT_TOP);
		
		UIRelativeLayout rootLayout = new UIRelativeLayout("rootLayout", 0f, 0f, 1f, 1f, null, UIAnchorLocation.LEFT_BOT);
		
		UIStringLabel backLabelSmall = new UIStringLabel(0.01f, 0.99f, 0.2f, 0.1f, null, UILayoutType.RELATIVE_LAYOUT, UIAnchorLocation.LEFT_TOP, backTextInfo, "Back");
		UIStringLabel backLabelLarge = new UIStringLabel(0.01f, 0.99f, 0.2f, 0.1f, null, UILayoutType.RELATIVE_LAYOUT, UIAnchorLocation.LEFT_TOP, backTextLargerInfo, "Back");
		UIStaticButton backButton = new UIStaticButton(0.01f, 0.99f, 0.1f, 0.08f, null, UILayoutType.RELATIVE_LAYOUT, UIAnchorLocation.LEFT_TOP, new MenuButtonListener(hover, dehover, "MainMenu"));

		backButton.SetUIComponentIdle(backLabelSmall).SetUIComponentHighlighted(backLabelLarge);

		UITextInfo mainTextInfo = new UITextInfo();
		mainTextInfo.SetFont(fontMain).SetFontSize(48).SetColor(new Color(1f, 1f, 1f)).SetTextAlignment(UIAnchorLocation.LEFT_TOP);

		UIStringLabel mainTextLabel = new UIStringLabel(0.15f, 0.8f, 0.9f, 0.5f, null, UILayoutType.RELATIVE_LAYOUT, UIAnchorLocation.LEFT_TOP, mainTextInfo, mainText);

		rootLayout.AddUIComponent(backButton)
			.AddUIComponent(mainTextLabel);

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

