using UnityEngine;
using System.Collections;

[RequireComponent (typeof (Renderer))]
public class BackgroundFader : MonoBehaviour {
	public Color tint = Color.white;
	private float timer;
	public float fadeTime=3;
	public bool fadeIn;
	private float alphaMin = 0.4f;
	private float alphaMax = 0.9f;

	void Start(){
		tint.a = alphaMax;
		renderer.material.color = tint;
	}



	// Update is called once per frame
	void Update () {
		if (timer < fadeTime) {
			timer+=Time.deltaTime;	

			if(timer>=fadeTime){
				timer=0;
				fadeIn=!fadeIn;
			}
		}

		if (fadeIn) {
			tint.a = (timer/fadeTime)*(alphaMax-alphaMin)+alphaMin;		
		}
		else{
			tint.a = ((fadeTime-timer)/fadeTime)*(alphaMax-alphaMin)+alphaMin;
		}

		renderer.material.color = tint;
	}
}
