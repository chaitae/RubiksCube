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
    // Start is called before the first frame update
    
    void RotateOnClick()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit, 100f, mask))
            {
                if(hit.transform.name.Contains("Top"))
                {
                    RubikController.instance.RotateFace(FaceType.Top);
                }
                else if(hit.transform.name.Contains("Front"))
                {
                    RubikController.instance.RotateFace(FaceType.Front);
                }
                else if (hit.transform.name.Contains("Left"))
                {
                    RubikController.instance.RotateFace(FaceType.Left);
                }
                else if (hit.transform.name.Contains("Right"))
                {
                    RubikController.instance.RotateFace(FaceType.Right);
                }
                else if(hit.transform.name.Contains("Bottom"))
                {
                    RubikController.instance.RotateFace(FaceType.Bottom);
                }
                else if (hit.transform.name.Contains("Back"))
                {
                    RubikController.instance.RotateFace(FaceType.Back);
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
