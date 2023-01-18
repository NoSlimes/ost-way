using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuCursor : MonoBehaviour
{

    float timer;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (timer > 0)
        {
            timer += Time.deltaTime;
            if (timer  >  1.0f)
            {
                Debug.Log("DoMenuSelection();");
                timer = 0;
            }
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            timer = 0.001f;
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            if (timer > 0)
            {
                Debug.Log("AdvanceMenuSelection();");
                timer = 0;
            }
        }





    }
}
