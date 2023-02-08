using NoSlimesJustCats;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

[RequireComponent(typeof(Rigidbody))]
public class MovingScript : MonoBehaviour
{
    private float FirstClickingTime;
    private float TimeBetweenClicks = 1;
    private bool MayIDuble = false;
    private int AmountOfClicks = 0;

    public GameObject UIObject;
    public GameObject UIForward;
    public GameObject UIRight;
    public GameObject UILeft;

    private Rigidbody2D rb;
    public float speed;

    public UnityEvent playerEnterTrigger;
    public UnityEvent playerExitTrigger;

    // Start is called before the first frame update
    void Start()
    {
        UIForward.SetActive(false); 
    }

    // Update is called once per frame
    void Update()
    {
        if (AmountOfClicks == 1 && MayIDuble == true)
        {
           
            UILeft.SetActive(true);
            Debug.Log("LEFT");
        }
        else
        {
            UILeft.SetActive(false);
        }
        if (AmountOfClicks == 2 && MayIDuble == true)
        {
            
            UIRight.SetActive(true);
            Debug.Log("RIGHT");
        }
        else
        {
            UIRight.SetActive(false);
        }
        if (AmountOfClicks == 0 && MayIDuble == true)
        {
           
            UIForward.SetActive(true);
            Debug.Log("Forward");
        }
        else
        {
            UIForward.SetActive(false);
        }
        if (AmountOfClicks == 3)
        {
            AmountOfClicks = 0;
        }
        transform.position += transform.forward * speed * Time.deltaTime;
        if (Input.GetButtonDown("Button"))
        {
            AmountOfClicks += 1;
        }
        if (AmountOfClicks == 1 && MayIDuble)
        {
            FirstClickingTime = Time.time;
            StartCoroutine(CheckDubleClick());
        }

        if(Input.GetKeyDown(KeyCode.V)){
            playerEnterTrigger.Invoke();
        }
    }

    private IEnumerator CheckDubleClick()
    {
       
        while(Time.time < FirstClickingTime + TimeBetweenClicks)
        {
            if(AmountOfClicks == 2)
            {
                Debug.Log("I did it Twice");
                break;
            }
           
           
            yield return new WaitForEndOfFrame();
        }
       
        
    }


    void OnTriggerEnter(Collider other)
    {
        //if(other.gameObject.tag != "ClickTrigger") { return; }

        if (!other.CompareTag("Wall"))
        {
            MayIDuble = true;

            UIObject.SetActive(true);

            playerEnterTrigger.Invoke();
            AmountOfClicks = 0;
        }
        else
        {
            SceneChanger.instance.ChangeScene("FailScene");
            AudioManager.instance.Play("mouseDEAD");
        }
    }
    void OnTriggerExit(Collider other)
    {
        //if (other.gameObject.tag != "TurnTrigger") { return; }
        if (AmountOfClicks == 1   )
        {
            Left();
            Debug.Log("LEFT");
        }
        if(AmountOfClicks == 2)
        {
            Right();
            Debug.Log("RIGHT");
        }
        if (AmountOfClicks == 0)
        {
            Debug.Log("Forward");
        }
        MayIDuble = false;

        UIObject.SetActive(false);

        speed *= 1.05f;

        AmountOfClicks = 0;

        playerExitTrigger.Invoke();

    }
    void Right()
    {
        transform.Rotate(0f, 90.0f, 0f, Space.Self);
    }
    void Left()
    {
        transform.Rotate(0f, -90.0f, 0f, Space.Self);




    }
}
