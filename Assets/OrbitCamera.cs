using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbitCamera : MonoBehaviour
{
    public float speedH = 20.0f;
    public float speedV = 2.0f;

    private float yaw = 0.0f;
    private float pitch = 0.0f;
    float rotSpeed = 20;
    public GameObject rubikCube;
    Vector3 mPosDelta = Vector3.zero;
    Vector3 mPrevPos = Vector3.zero;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(Input.GetAxis("Vertical"));
        if(Input.GetAxis("Horizontal") >0)
        {
            //rubikCube.transform.Rotate(Vector3.left);
            transform.RotateAround(rubikCube.transform.position, new Vector3(0, 1, 0), speedH * Time.deltaTime);
            //Debug.Log("horizontal");

        }
        else if(Input.GetAxis("Horizontal")<0)
        {
            transform.RotateAround(rubikCube.transform.position, new Vector3(0, -1, 0), speedH * Time.deltaTime);

        }

        if (Input.GetAxis("Vertical") > 0)
        {
            transform.RotateAround(rubikCube.transform.position, new Vector3(-1, 0, 0), speedV * Time.deltaTime);

        }
        else if (Input.GetAxis("Vertical") < 0)
        {
            transform.RotateAround(rubikCube.transform.position, new Vector3(1, 0, 0), speedV * Time.deltaTime);

        }
    }

}
