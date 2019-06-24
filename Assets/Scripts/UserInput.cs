using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserInput : MonoBehaviour
{

    public LayerMask mask;
    bool isRightClick;
    bool isScrambled = false;
    Vector2 input;
    public GameObject target;
    public float speed = 8f;
    public float distance =10f;

    void RotateOnClick()
    {
        if (Input.GetMouseButtonDown(0) || Input.GetMouseButtonDown(1))
        {
            if(Input.GetMouseButton(0))
            {
                isRightClick = true;
            }
            else
            {
                isRightClick = false;
            }
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit, 100f, mask))
            {
                if(hit.transform.name.Contains("Top"))
                {
                    RubikController.instance.RotateFace(FaceType.Top,isRightClick);
                }
                else if(hit.transform.name.Contains("Front"))
                {
                    RubikController.instance.RotateFace(FaceType.Front,isRightClick);
                }
                else if (hit.transform.name.Contains("Left"))
                {
                    RubikController.instance.RotateFace(FaceType.Left,isRightClick);
                }
                else if (hit.transform.name.Contains("Right"))
                {
                    RubikController.instance.RotateFace(FaceType.Right,isRightClick);
                }
                else if(hit.transform.name.Contains("Bottom"))
                {
                    RubikController.instance.RotateFace(FaceType.Bottom,isRightClick);
                }
                else if (hit.transform.name.Contains("Back"))
                {
                    RubikController.instance.RotateFace(FaceType.Back,isRightClick);
                }
            }
        }
    }
    // Update is called once per frame
    void Update()
    {
        if(Input.GetAxis("Horizontal") >0 ||Input.GetAxis("Horizontal")<0 ||Input.GetAxis("Vertical")>0 ||Input.GetAxis("Vertical")<0)
        {
            input += new Vector2(Input.GetAxis("Horizontal") * speed, Input.GetAxis("Vertical") * speed);
            transform.localRotation = Quaternion.Euler(input.y, input.x, 0);
            transform.localPosition = target.transform.position - (transform.localRotation * Vector3.forward * distance);
        }

        if(isScrambled)
        RotateOnClick();
    }
    private void SetScrambledFalse()
    {
        isScrambled = false;
    }
    private void SetScrambledTrue()
    {
        isScrambled = true;
    }

    void OnEnable()
    {
        RubikController.OnScrambled += SetScrambledTrue;
        GameManager.OnReset += SetScrambledFalse;
        
    }

    void OnDisable()
    {
        RubikController.OnScrambled -= SetScrambledTrue;
        GameManager.OnReset -= SetScrambledFalse;
    }
}
