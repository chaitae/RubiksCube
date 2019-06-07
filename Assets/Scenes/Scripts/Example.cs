using UnityEngine;

public class Example : MonoBehaviour
{
    public float speed = 90;
    public GameObject rotatePoint;
    public Vector3 rotatePointVec;
    private void Awake()
    {
        //rotatePointVec = rotatePoint.transform.position;
    }
    void Update()
    {
        // Spin the object around the world origin at 20 degrees/second.
        transform.Rotate(0,0 , speed * Time.deltaTime);
        //transform.RotateAroundLocal(rotatePointVec,20);
        //transform.RotateAround(rotatePoint, Vector3.up, degrees * Time.deltaTime);
    }
}