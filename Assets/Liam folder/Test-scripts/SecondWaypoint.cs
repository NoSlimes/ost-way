using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecondWaypoint : MonoBehaviour
{
    public static Transform[] DiffrentPath;

    void Awake()
    {
        DiffrentPath = new Transform[transform.childCount];
        for (int i = 0; i < DiffrentPath.Length; i++)
        {
            DiffrentPath[i] = transform.GetChild(i);

            if (i >= DiffrentPath.Length)
            {
                i = 0;
            }
        }
    }
}






