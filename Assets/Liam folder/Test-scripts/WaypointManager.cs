using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointManager : MonoBehaviour
{
    public static WaypointManager Instance;

    [SerializeField]
    private List<GameObject> waypoints;

    public List<GameObject> Waypoints => waypoints;

    private void Awake()
    {
        Instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
