using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RubikController : MonoBehaviour
{
    public static RubikController instance = null;
    public RubikModel rubikModel;
    bool canRotate = true;
    public float offset = 5f;
    Vector3 initial = new Vector3();
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
    public void RotateFace(FaceType face)
    {
        if(canRotate)
        {
            switch (face)
            {
                case FaceType.Front:
                    StartCoroutine(RotateFaceHelper(rubikModel.front.ToArray(), new Vector3(0, 0, 1)));
                    break;
                case FaceType.Back:
                    StartCoroutine(RotateFaceHelper(rubikModel.back.ToArray(), new Vector3(0, 0, 1)));
                    break;
                case FaceType.Bottom:
                    StartCoroutine(RotateFaceHelper(rubikModel.bottom.ToArray(), Orbit.horizontalCLockwise)); //top
                    break;
                case FaceType.Left:
                    StartCoroutine(RotateFaceHelper(rubikModel.left.ToArray(), Orbit.verticleClockwise));
                    break;
                case FaceType.Right:
                    StartCoroutine(RotateFaceHelper(rubikModel.right.ToArray(), Orbit.verticleClockwise));
                    break;
                default:
                    StartCoroutine(RotateFaceHelper(rubikModel.top.ToArray(), Orbit.horizontalCLockwise)); //top
                    break;
            }
        }

    }
    IEnumerator RotateFaceHelper(GameObject[] face, Vector3 direction)
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
    void IncrementRotate(GameObject[] face, Vector3 direction)
    {
        GameObject pivot = GetPivot(face);

        foreach (GameObject go in face)
        {
            go.transform.RotateAround(pivot.transform.position, direction, 5f);

        }
    }

}
