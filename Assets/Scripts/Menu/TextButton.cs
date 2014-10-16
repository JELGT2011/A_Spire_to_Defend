using UnityEngine;
using System.Collections;

public class TextButton : MonoBehaviour {
	public string levelName = "Level1";

	void OnMouseEnter(){
		guiText.fontSize += 5;
	}

	void OnMouseExit(){
		guiText.fontSize -= 5;

	}

	void OnMouseDown(){
		Application.LoadLevel (levelName);
	}
}
