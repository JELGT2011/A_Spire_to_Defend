using UnityEngine;
using System.Collections;
using UINamespace;

public class MenuButtonListener : IUIButtonListener
{
	private string levelName;
	private AudioClip hover;
	private AudioClip dehover;

	public MenuButtonListener(AudioClip hover, AudioClip dehover, string levelName)
	{
		this.hover = hover;
		this.dehover = dehover;
		this.levelName = levelName;
	}

	public void OnHighlighted()
	{
		AudioSource.PlayClipAtPoint(hover, Vector3.zero);
	}

	public void OnIdle()
	{
		AudioSource.PlayClipAtPoint(dehover, Vector3.zero);
	}

	public void OnSelected()
	{
		Application.LoadLevel(levelName);
	}
}


