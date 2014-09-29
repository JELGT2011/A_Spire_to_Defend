using UnityEngine;
using System.Collections;
using System.ComponentModel;

public class CameraControls : MonoBehaviour
{
    public KeyCode MoveForward  = KeyCode.W;
    public KeyCode MoveBackward = KeyCode.S;
    public KeyCode MoveLeft     = KeyCode.A;
    public KeyCode MoveRight    = KeyCode.D;

    public KeyCode ZoomOut      = KeyCode.Q;
    public KeyCode ZoomIn       = KeyCode.E;

    public int Speed = 4;

    public int ScrollSpeed = 30;

	public Transform wallLeft, wallRight, wallUp, wallDown;

    void Update()
    {
        InputMovement();
    }

    void InputMovement()
    {
        if (Input.GetKey(MoveForward) && (wallUp!=null || transform.position.z>wallUp.position.z))
        {
            transform.Translate(Vector3.forward * Speed * Time.deltaTime);
        }

		if (Input.GetKey(MoveBackward)&& (wallDown!=null || transform.position.z<wallDown.position.z))
        {
            transform.Translate(Vector3.back * Speed * Time.deltaTime);
        }

		if (Input.GetKey(MoveLeft)&& (wallLeft!=null || transform.position.x>wallLeft.position.x))
        {
            transform.Translate(Vector3.left * Speed * Time.deltaTime);
        }

		if (Input.GetKey(MoveRight)&& (wallRight!=null || transform.position.x<wallRight.position.x))
        {
            transform.Translate(Vector3.right * Speed * Time.deltaTime);
        }

        if (Input.GetAxis("Mouse ScrollWheel") > 0 || Input.GetKey(ZoomIn))
        {
			float currSize = Camera.main.orthographicSize;
			if(currSize-ScrollSpeed*Time.deltaTime>1){
				Camera.main.orthographicSize-=ScrollSpeed*Time.deltaTime;
			}
        }

        if (Input.GetAxis("Mouse ScrollWheel") < 0 || Input.GetKey(ZoomOut))
        {
			Camera.main.orthographicSize+=ScrollSpeed*Time.deltaTime;
        }
    }
}
