using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RubikController : MonoBehaviour
{
    public static RubikController instance = null;
    public RubikModel rubikModel;
    bool canRotate = true;
    bool scrambled = false;
    public float offset = 5f;
    Vector3 initial = new Vector3();
    void OnEnable()
    {
        GameManager.OnReset += Scramble;
    }
    void OnDisable()
    {
        GameManager.OnReset -= Scramble;
    }

    private void Scramble()
    {
        StartCoroutine(ScrambleCube());
    }
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
        StartCoroutine(ScrambleCube());
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
    public void RotateFace(FaceType face,bool clockWise)
    {
        int flipNumber = -1;
        if(clockWise)
        {
            flipNumber = 1;
        }
        if(canRotate)
        {
            switch (face)
            {
                case FaceType.Front:
                    StartCoroutine(RotateFaceHelper(rubikModel.front.ToArray(), new Vector3(0, 0, -1)*flipNumber));
                    break;
                case FaceType.Back:
                    StartCoroutine(RotateFaceHelper(rubikModel.back.ToArray(), new Vector3(0, 0, 1)*flipNumber));
                    break;
                case FaceType.Bottom:
                    StartCoroutine(RotateFaceHelper(rubikModel.bottom.ToArray(), -1*Orbit.horizontalCLockwise*flipNumber));
                    break;
                case FaceType.Left:
                    StartCoroutine(RotateFaceHelper(rubikModel.left.ToArray(), Orbit.verticleClockwise*flipNumber));
                    break;
                case FaceType.Right:
                    StartCoroutine(RotateFaceHelper(rubikModel.right.ToArray(), -1*Orbit.verticleClockwise*flipNumber));
                    break;
                default:
                    StartCoroutine(RotateFaceHelper(rubikModel.top.ToArray(), Orbit.horizontalCLockwise*flipNumber)); //top
                    break;
            }
        }

    }
    IEnumerator ScrambleCube()
    {
        for(int i =0; i<2;i++)
        {
            int numbSides = 6;
            int ranIndex = Random.Range(0, numbSides);
            RotateFace((FaceType)ranIndex,true);
            yield return new WaitForSeconds(1);
        }
        scrambled = true;
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
        if(scrambled)
        {
            if(CheckSolved())
            {
                Debug.Log("puzzle solved");
                GameManager.instance.Win();
            }
        }
        canRotate = true;
    }
    bool CheckSolved()
    {
        foreach(GameObject child in rubikModel.allPieces)
        {
            if(Mathf.Round(child.transform.localRotation.eulerAngles.x) != 0 || Mathf.Round(child.transform.localRotation.eulerAngles.z) != 0 || Mathf.Round(child.transform.localRotation.eulerAngles.y) != 0)
            {
                return false;
            }
        }
        return true;
    }

}
