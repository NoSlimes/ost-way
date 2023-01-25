using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupObject : MonoBehaviour
{
    private void OnTriggerEnter(Collider collider)
    {
        // If the gameObject collides with another gameObject with the tag "Player" the script activates
        if(collider.gameObject.tag == "Player")
        {
            // Writes a message and destroys gameObject
            print("You got a Power Up!");
            Destroy(gameObject, 2.0f);
        }
    }
}
