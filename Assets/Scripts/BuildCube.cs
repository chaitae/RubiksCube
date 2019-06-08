using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildCube : MonoBehaviour
{
    public GameObject cubePrefab;
    public float offset = 10;
    // Start is called before the first frame update
    void Start()
    {
        for(int x = 0; x<3;x++)
        {
            for(int y =0; y<3;y++)
            {
                for(int z = 0; z<3;z++)
                {
                    Instantiate(cubePrefab, new Vector3(x*offset,y*offset,z*offset), Quaternion.identity);
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
