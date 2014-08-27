using UnityEngine;
using System.Collections;

public class PongPlayer : Photon.MonoBehaviour {

    public float speed = 10f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (photonView.isMine)
        {
            InputMovement();
        }
	}

    void InputMovement()
    {
        if (Input.GetKey(KeyCode.W))
        {
            rigidbody.MovePosition(rigidbody.position + Vector3.up * speed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.S))
        {
            rigidbody.MovePosition(rigidbody.position + Vector3.down * speed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.A))
        {
            rigidbody.MovePosition(rigidbody.position + Vector3.left * speed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.D))
        {
            rigidbody.MovePosition(rigidbody.position + Vector3.right * speed * Time.deltaTime);
        }    
    }
}
