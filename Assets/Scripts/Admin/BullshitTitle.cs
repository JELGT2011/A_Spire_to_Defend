using UnityEngine;
using System.Collections;

public class BullshitTitle : MonoBehaviour {
	private string start = "A Spire Of \n";
	private string[] end = new string[]{"Defendrs", "Baby Boomer \nDistrust of \nMillennials", "VGDevs", "Vague \nDisappointment",
		"Freaking \nNERDS", "Blood Loss", "Graphic T-shirts", "Hipster Glasses", "No Shave \nNovember", "Skinny Jeans", 
		"Christmas", "Halloween", "Thanksgiving", "Distrust of Authority", "Unexplainable Rage", "The loss of \ninnocence",
	"What the heck", "[Insert Title Here]", "Titles", "Endless Questions", "Two more weeks"};


	// Use this for initialization
	void Start () {
		guiText.text = start + end [Random.Range (0, end.Length)];
	}

}
