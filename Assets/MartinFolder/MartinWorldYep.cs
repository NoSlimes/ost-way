using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MartinWorldYep : MonoBehaviour
{
    public GameObject blockGameObject;

    private int WorldSizeX = 10;
    private int WorldSiezeZ = 10;

    private int gridoffset = 2;
    // Start is called before the first frame update
    void Start()
    {
        for (int x = 0; 0 < WorldSizeX; x++)
        {
            for (int z = 0; z < WorldSiezeZ; z++)
            {
                Vector3 pos = new Vector3(x * gridoffset, 0, z * gridoffset);
                GameObject block = Instantiate(blockGameObject, pos, Quaternion.identity) as GameObject;
                block.transform.SetParent(this.transform);
            }
        }
    }
}
