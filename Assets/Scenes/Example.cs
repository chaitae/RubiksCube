using UnityEngine;

public class Example : MonoBehaviour
{
    public float degrees = 90;
    public Vector3 rotatePoint;
    void Update()
    {
        // Spin the object around the world origin at 20 degrees/second.
        transform.RotateAround(rotatePoint, Vector3.up, degrees * Time.deltaTime);
    }
}