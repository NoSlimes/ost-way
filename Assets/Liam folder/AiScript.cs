using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AiScript : MonoBehaviour
{

    //Variables;
    public Transform target;
    public float speed = 4f;
    public NavMeshAgent navMeshAgent;
    private MovingScript playerMovement;


    // Start is called before the first frame update
    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        playerMovement = target.gameObject.GetComponent<MovingScript>();
    }

    // Update is called once per frame
    void Update()
    {
        navMeshAgent.destination = target.position;
        navMeshAgent.speed = playerMovement.speed;

        //Makes the enemy move towards player
        //Vector3 pos = Vector3.MoveTowards(transform.position, target.position, speed * Time.fixedDeltaTime);
        //rig.MovePosition(pos);
        //transform.LookAt(target);
    }
}

