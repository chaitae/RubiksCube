using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum FaceType
{
    Front,Back,Top,Left,Right,Bottom
}
public class RubikView : MonoBehaviour
{
    public FaceType faceCollideCheck;
    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "cube")
        {
            bool removeCube = false;
            RubikController.instance.UpdateBlockFaces(faceCollideCheck, removeCube, other.gameObject);
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.tag == "cube")
        {
            bool removeCube = true;
            RubikController.instance.UpdateBlockFaces(faceCollideCheck, removeCube, other.gameObject);
        }
    }
}
