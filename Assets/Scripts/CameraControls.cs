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

    void Update()
    {
        InputMovement();
    }

    void InputMovement()
    {
        if (Input.GetKey(MoveForward))
        {
            transform.Translate(Vector3.forward * Speed * Time.deltaTime);
        }

        if (Input.GetKey(MoveBackward))
        {
            transform.Translate(Vector3.back * Speed * Time.deltaTime);
        }

        if (Input.GetKey(MoveLeft))
        {
            transform.Translate(Vector3.left * Speed * Time.deltaTime);
        }

        if (Input.GetKey(MoveRight))
        {
            transform.Translate(Vector3.right * Speed * Time.deltaTime);
        }

        if (Input.GetAxis("Mouse ScrollWheel") > 0 || Input.GetKey(ZoomIn))
        {
            gameObject.GetComponentInChildren<Transform>().Translate(Vector3.forward * Time.deltaTime * ScrollSpeed, Camera.main.transform);
        }

        if (Input.GetAxis("Mouse ScrollWheel") < 0 || Input.GetKey(ZoomOut))
        {
            gameObject.GetComponentInChildren<Transform>().Translate(Vector3.back * Time.deltaTime * ScrollSpeed, Camera.main.transform);
        }
    }
}
