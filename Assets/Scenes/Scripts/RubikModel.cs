using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class RubikModel:MonoBehaviour
{
    public GameObject[] allPieces;
    public List<GameObject> top;
    public List<GameObject> front;
    public List<GameObject> back;
    public List<GameObject> right;
    public List<GameObject> left;
    public List<GameObject> bottom;
    private void Awake()
    {
        front = new List<GameObject>();
    }
}
