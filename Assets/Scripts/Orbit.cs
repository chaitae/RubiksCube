using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Orbit : MonoBehaviour
{
    public GameObject pivotPoint;
    private float speed =90;
    Vector3 rotateDirection = Vector3.zero;
    public static Vector3 horizontalCLockwise = new Vector3(0,1,0);
    public static Vector3 verticleClockwise = Vector3.left;
    int currAngle = 90;
    bool isMoving = false;
    int[] rotationAngles = { -180, -90 };
    int indexRotationAngles = 0;
    // Start is called before the first frame update
    void Start()
    {

    }
    public void ChangePivotPoint(GameObject pivot)
    {
        pivotPoint = pivot;
    }
    public void SetRotation(Vector3 vec)
    {
        rotateDirection = vec;
        RotateCube();
        //isMoving = true;
        //Debug.Log(transform.p)
    }
    void RotateCube()
    {
        transform.RotateAround(pivotPoint.transform.position, rotateDirection, speed);

    }
    void UpdateRotationAngle()
    {
        if(indexRotationAngles == rotationAngles.Length-1)
        {
            indexRotationAngles = 0;
        }
        else
        {
            indexRotationAngles++;
        }
        currAngle = rotationAngles[indexRotationAngles];
        Debug.Log(currAngle);
    }
    // Update is called once per frame
    void Update()
    {
        //if state move
        //Debug.Log(speed * Time.deltaTime);
        if(isMoving)
        {
            if (Mathf.Abs(transform.localEulerAngles.y) < Mathf.Abs(currAngle))
            {
                Debug.Log(transform.localEulerAngles.y);
                transform.RotateAround(pivotPoint.transform.position, rotateDirection, speed * Time.deltaTime);
            }
            else
            {
                isMoving = false;
                UpdateRotationAngle();
                //if(transform.localRotation.y ==-90)
                //{
                //    currAngle = 0;
                //}
                //currAngle += 90;
            }
        }
        

    }
}
