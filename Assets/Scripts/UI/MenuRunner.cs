using UnityEngine;
using System.Collections;
using UINamespace;

public class MenuRunner : MonoBehaviour
{
	public Camera m_camera;
	private UI m_ui;

	void Start()
	{
		m_ui = new UI(UIEnum.TEST_UI);
	}

	void OnGUI()
	{
		m_ui.OnGUI();
	}
}
