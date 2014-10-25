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

	void Start()
	{
		m_ui = new UI(UIEnum.TEST_UI, m_font);
		m_ui.SetStartMenu(UIEnum.TEST_MENU1);

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
