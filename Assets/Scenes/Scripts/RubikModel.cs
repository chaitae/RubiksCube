using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class RubikModel:MonoBehaviour
{
    //public GameObject[] rubikBlock;
    //public GameObject[] allPieces;
    //public GameObject[] top;
    public List<GameObject> top;
    public List<GameObject> front;
    public List<GameObject> back;
    public List<GameObject> right;
    public List<GameObject> left;
    public List<GameObject> bottom;

    //public Vector3[] topPiecePosition = new Vector3[9];

    public string bah;
    private void Awake()
    {
        front = new List<GameObject>();
           //topPiecePosition = new Vector3[9];

    }
    public void UpdateBlockPosition()
    {

    }
    // Start is called before the first frame update

}
