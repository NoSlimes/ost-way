using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]

public class Movement : MonoBehaviour
{


    public bool InsideCollider = false;
    public bool Ipressed1 = false;
    public bool Ipressed2 = false;
    public float DubleClick = 0;



    [SerializeField] private float Movementspeed = 2f;


    private Rigidbody2D rb;
    private float speed;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //which button
       /* if (Input.GetButtonDown("Fire2"))
        {
            Ipressed1 = true;
        }
        if (Input.GetButtonDown("Fire2")) && (DubleClick < 2);
        {
            Ipressed1 = false;
            Ipressed2 = true;
        }
        transform.position += transform.forward * Movementspeed * Time.deltaTime;

    }
    void OnTriggerEnter(Collider other)
    {
        InsideCollider = true;
    }
    void OnTriggerExit(Collider other)
    {
        InsideCollider = false;
        {
            if (Ipressed1 == true)
            {
                Left();
                Ipressed1 = false;
                Ipressed2 = false;
            }
            if (Ipressed2 == false)
            {
                Right();
                Ipressed1 = false;
                Ipressed2 = false;
            }
            return;

        }
    }
    void Right()
    {
        transform.Rotate(0f, 90.0f, 0f, Space.Self);
    }
    void Left()
    {
        transform.Rotate(0f, -90.0f, 0f, Space.Self);
    */
    
    
    }


}