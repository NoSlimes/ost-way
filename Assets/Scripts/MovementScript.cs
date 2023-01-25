using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementScript : MonoBehaviour
{
    
    public bool InsideCollider = false;
    public bool Ipressed = false;
    
       
      
    
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
         if (Input.GetKeyDown(KeyCode.K))
        {
            Ipressed = true;
        }
        transform.position += transform.up * Movementspeed * Time.deltaTime;
        
    }
    void OnTriggerEnter(Collider other)
    {
        InsideCollider = true;
    }
    void OnTriggerExit(Collider other)
    {
        InsideCollider = false;
        {
            if (Ipressed == true)
            {
                Left();
            }
            if (Ipressed == false)
            {
                Right();
            }
            return;

        }
    }      
    void Right()
    {
        transform.Rotate(0.0f, 0.0f, 90.0f, Space.Self);
    }
    void Left()
    {
        transform.Rotate(0.0f, 0.0f, -90.0f, Space.Self);
    }

}
