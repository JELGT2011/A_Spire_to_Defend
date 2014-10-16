using UnityEngine;
using System.Collections;

//Just an info holder
public class TowerInfo : MonoBehaviour {
	public GUIText number;
	public GUITexture icon;

	public void SetNumber(int key){
		number.text = "" + key;
	}
}
