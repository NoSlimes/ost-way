using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.Rendering.UI;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.WSA;
using Application = UnityEngine.Application;

public class MainMenu : MonoBehaviour
{
    //vairables to cennect to the scenes you use
    public string AntCredits;
    public string firstLevel;
    public string AntMenu;
    public string sceneName;

    //variables for the button navigation
    public float setButton;
    public float downTimePress = 0;
    public float downTimePressF = 0;
    public Boolean buttonSelected = false;
    
    //creates a variable for a game object
    private GameObject myHStartButton;
    private GameObject myHCreditButton;
    private GameObject myHExitButton;

    //variables for the visual confirmation
    public Image confirmation;
    public bool holding;
    public float confirmTime = 2.0f;
    public bool doNotSpin;


    // Start is called before the first frame update
    void Start()
    {
        setButton = 0;
        
        //stores what scene is active at the moment
        Scene currentScene = SceneManager.GetActiveScene();

        //sets the variable sceneName with the name of the current scene
        sceneName = currentScene.name;
        print(sceneName);
        downTimePress = 0;
        
        //tells the game object variable to find the game object I want it to interact with
        myHStartButton = GameObject.Find("HStartButton");
        myHCreditButton = GameObject.Find("HCreditButton");
        myHExitButton = GameObject.Find("HExitButton");

        //setup for the visual confirmation
        doNotSpin = false;
        confirmation.fillAmount = 0;
    }

    

    // Update is called once per frame
    void Update()
    {
        //to leave the credit menu
        if (Input.GetKeyDown(KeyCode.Alpha1) && (sceneName == AntCredits))
        {
            print("Back to Menu");
            menu();
        }
        
        //get the time that you pressed down the button
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            downTimePressF = Time.time;
            holding = true;
        }

        //This makes sure that visual confirmation resets when the button is let go
        if (holding == false)
        {
            confirmation.fillAmount = 0;
        }

        //this is what fills the visual confirmation
        if (holding == true && doNotSpin == false)
        {
            confirmation.fillClockwise = true;
            confirmation.fillAmount += 1.0f / confirmTime * Time.deltaTime;
            
            //this makes sure that the visual confirmation doesn't loop
            if (confirmation.fillAmount == 1)
            {
                doNotSpin = true;
                print("good to go");
            }
        }

        //get the time that you released the button
        if (Input.GetKeyUp(KeyCode.Alpha1))
        {
            downTimePress = Time.time;
            holding = false;
            //find the time that passed between when you pressed the button and when you released the button
            if (downTimePress - downTimePressF > 2) 
            {
                //if time is larger than 4 seconds then you are good to go
                buttonSelected = true;
                print("button Pressed"); 
                doNotSpin=false;
            }
            else { print("Next option"); }
        }

        //change highlighted button
        if (Input.GetKeyUp(KeyCode.Alpha1))
        {
            //so it doesn't changed the highighted button at the last second
            if (buttonSelected == false)
            {
                setButton = setButton + 1;

                //so it goes back to option 0 or the "start" button
                if (setButton >= 3)
                {
                    setButton = 0;
                    Debug.Log(setButton);
                }
            }
        }

        //this checks what button is selected and makes sure that button is highlighted
        if ((setButton == 0) && (sceneName == AntMenu))
        {
            myHStartButton.SetActive(true);
        }
        else if(sceneName == AntMenu)
        {
            myHStartButton.SetActive(false);
        }

        if ((setButton == 1) && (sceneName == AntMenu))
        {
            myHCreditButton.SetActive(true);
        }
        else if (sceneName == AntMenu)
        {
            myHCreditButton.SetActive(false);
        }

        if ((setButton == 2) && (sceneName == AntMenu))
        {
            myHExitButton.SetActive(true);
        }
        else if (sceneName == AntMenu)
        {
            myHExitButton.SetActive(false);
        }


        //what happens when you press the highlighted button
        if ((downTimePress - downTimePressF > 2) && (sceneName == AntMenu))
        {
            //game starts
            if ((buttonSelected == true) && (setButton == 0))
            {
                print("Starting game");
                StartGame();
                buttonSelected = false;
            }
            //opens credit page
            if ((buttonSelected == true) && (setButton == 1))
            {
                print("Watching credits");
                AntCredit();
                buttonSelected = false;
            }
            //closes the game
            if ((buttonSelected == true) && (setButton == 2))
            {
                print("Murdering game");
                QuitGame();
                buttonSelected = false;
            }
        }
    }
    // scene changes
    public void StartGame()
    {
        //SceneManager.LoadScene(firstLevel);
        NoSlimesJustCats.SceneChanger.instance.ChangeScene(firstLevel);
    }
    

    //the part that closes the game
    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Quittign");
    }

    //the part that opens the credits
    public void AntCredit()
    {
        //SceneManager.LoadScene(AntCredits);
        NoSlimesJustCats.SceneChanger.instance.ChangeScene(AntCredits);
    }

    //the part that sends the player back to the menu from the credits
    public void menu()
    {
        //SceneManager.LoadScene(AntMenu);
        NoSlimesJustCats.SceneChanger.instance.ChangeScene(AntMenu);
    }
}