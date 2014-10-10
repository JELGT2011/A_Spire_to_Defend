using UnityEngine;
using System.Collections;

public class FreezeEffect : MonoBehaviour {
	private Color oldColor;
	public Color frozenColor = Color.blue;

	public float lifespan = 10f;

	private float oldFireRate;

	void Start(){
		Tower t = gameObject.GetComponent<Tower> ();
		oldFireRate = t._fireRate;
		t._fireRate = 0;
	}

	void Update(){
		lifespan -= Time.deltaTime;
		if (lifespan > 0) {
			Tower t = gameObject.GetComponent<Tower> ();
			t._fireRate = oldFireRate;
			GameObject.Destroy(this);		
		}

	}
}
