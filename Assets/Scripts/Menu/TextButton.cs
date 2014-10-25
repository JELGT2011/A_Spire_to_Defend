using UnityEngine;
using System.Collections;

public class TextButton : MonoBehaviour {
	public string levelName = "Level1";
	public AudioClip hover, dehover;

	void OnMouseEnter(){
		AudioSource.PlayClipAtPoint (hover, Vector3.zero);
		guiText.fontSize += 5;
	}

	void OnMouseExit(){
		AudioSource.PlayClipAtPoint (dehover, Vector3.zero);
		guiText.fontSize -= 5;

	}

	void OnMouseDown(){
		Application.LoadLevel (levelName);
	}
}
