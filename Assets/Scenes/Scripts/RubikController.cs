using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RubikController : MonoBehaviour
{
    public static RubikController instance = null;
    public RubikModel rubikModel;
    public RubikView rubikView;
    bool canRotate = true;
    public float offset = 5f;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this);
        }
    }
    public void UpdateBlockFaces(FaceType face,bool isRemoving,GameObject go)
    {
        switch(face)
        {
            case FaceType.Back:
                if(isRemoving)
                {
                    rubikModel.back.Remove(go);
                }
                else
                {
                    rubikModel.back.Add(go);
                }
                break;
            case FaceType.Front:
                if (isRemoving)
                {
                    rubikModel.front.Remove(go);
                }
                else
                {
                    rubikModel.front.Add(go);

                }
                break;
            case FaceType.Left:
                if (isRemoving)
                {
                    rubikModel.left.Remove(go);
                }
                else
                {
                    rubikModel.left.Add(go);
                }
                break;
            case FaceType.Right:
                if (isRemoving)
                {
                    rubikModel.right.Remove(go);
                }
                else
                {
                    rubikModel.right.Add(go);
                }
                break;
            case FaceType.Bottom:
                if (isRemoving)
                {
                    rubikModel.bottom.Remove(go);
                }
                else
                {
                    rubikModel.bottom.Add(go);
                }
                break;
            default:
                Debug.Log("top");

                if (isRemoving)
                {
                    rubikModel.top.Remove(go);
                }
                else
                {
                    rubikModel.top.Add(go);
                }
                break;
        }
    }
    GameObject GetPivot(GameObject[] face)
    {
        foreach(GameObject go in face)
        {
            if(go.name.Equals("pivot"))
            {
                return go;
            }
        }
        return null;
    }
    IEnumerator RotateFace(GameObject[] face, Vector3 direction)
    {
        canRotate = false;
        float angle = 0;
        GameObject pivot = GetPivot(face);
        while(angle < 90)
        {
            foreach(GameObject go in face)
            {
                go.transform.RotateAround(pivot.transform.position, direction, 5f);
                
            }
            angle = 5f + angle;

            yield return null; //until next frame
        }
        canRotate = true;
    }
    void Update()
    {
        //if(Input.GetMouseButtonDown(0) && canRotate)
        //{

        //    StartCoroutine(RotateFace(rubikModel.front.ToArray(),new Vector3(0,0,1)));
        //}
        if (Input.GetMouseButtonDown(1) && canRotate)
        {
            StartCoroutine(RotateFace(rubikModel.top.ToArray(), Orbit.horizontalCLockwise));
        }
        if(Input.GetMouseButton(2) && canRotate)
        {
            StartCoroutine(RotateFace(rubikModel.left.ToArray(), Orbit.verticleClockwise));
        }
        if(Input.GetKeyDown(KeyCode.Alpha1) && canRotate)
        {
            StartCoroutine(RotateFace(rubikModel.right.ToArray(), Orbit.verticleClockwise));

        }
        if (Input.GetKeyDown(KeyCode.Alpha2) && canRotate)
        {
            StartCoroutine(RotateFace(rubikModel.bottom.ToArray(), Orbit.horizontalCLockwise));

        }
        if (Input.GetKeyDown(KeyCode.Alpha3) && canRotate)
        {
            StartCoroutine(RotateFace(rubikModel.back.ToArray(), new Vector3(0,0,1)));

        }
    }
}
