using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum SwipeType
{
    left, right, up, down
}
public class UserInput : MonoBehaviour
{
    Vector3 initial;
    Vector3 end;
    public LayerMask mask;
    public float minimumDistance;
    GameObject lastClickedBlock;
    bool isRightClick;
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
        RotateOnClick();
    }
}
