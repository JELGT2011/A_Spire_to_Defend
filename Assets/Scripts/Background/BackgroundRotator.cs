using UnityEngine;
using System.Collections;

public class BackgroundRotator : MonoBehaviour {
	public float rotationSpeed=5f;

	
	// Update is called once per frame
	void Update () {
		transform.Rotate (Vector3.forward * Time.deltaTime * rotationSpeed);
	}
}
