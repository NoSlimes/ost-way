using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed = 10f;

    

    private Transform target;
    private int wavepointIndex = 0;

    void Start()
    {
        target = Waypoint.points[0];

    }

    public bool Ipressed ()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            return true;
        }
        else return false;
    }

    void Update()
    {
        Vector3 dir = target.position - transform.position;
        transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);


        if ( Vector3.Distance(transform.position, target.position) <= 0.2f)
        {
            if (!Ipressed())
            { 
                Left();
                return; 
            }
            Right();
        }
       
        if (wavepointIndex >= Waypoint.points.Length - 1)
        {
            wavepointIndex -= Waypoint.points.Length - 1;
        }

    }

    void Right()
    {

    }

    void Left()
    {
        wavepointIndex++;
        target = Waypoint.points[wavepointIndex];
    }

   
}
