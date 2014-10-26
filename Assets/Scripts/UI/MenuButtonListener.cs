using UnityEngine;
using System.Collections;

public class  PlayButtonListener : UINamespace.IUIButtonListener
{
	public void OnHighlighted()
	{
		Debug.Log("Play Button Highlighted");
	}
	public void OnIdle()
	{
		Debug.Log("Play Button Unhighlighed");
	}
	public void OnSelected()
	{
		Debug.Log(" >>> Play Button Selected");
	}
}

public class  TutorialButtonListener : UINamespace.IUIButtonListener
{
	public void OnHighlighted()
	{
		Debug.Log("Tutorial Button Highlighted");
	}
	public void OnIdle()
	{
		Debug.Log("Tutorial Button Unhighlighted");
	}
	public void OnSelected()
	{
		Debug.Log(" >>> Tutorial Button Selected");
	}
}

public class  CreditsButtonListener : UINamespace.IUIButtonListener
{
	public void OnHighlighted()
	{
		Debug.Log("Credits Button Highlighted");
	}
	public void OnIdle()
	{
		Debug.Log("Credits Button Unhighlighted");
	}
	public void OnSelected()
	{
		Debug.Log(" >>> Credits Button Selected");
	}
}

