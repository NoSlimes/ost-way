using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public string Credit;
    public string firstLevel;
    public string AntMenu;
    public float setButton;
    public string sceneName;
    public float downTimePress = 0;
    public float downTimePressF = 0;
    public Boolean buttonSelected = false;

    // Start is called before the first frame update
    void Start()
    {
        setButton = 0;

        Scene currentScene = SceneManager.GetActiveScene();

        sceneName = currentScene.name;
        print(sceneName);
        downTimePress = 0;
    }


    // Update is called once per frame
    void Update()
    {    
        //get the time that you pressed down the button
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            downTimePressF = Time.time;
        }

        //get the time that you released the button
        if (Input.GetKeyUp(KeyCode.Alpha1))
        {
            downTimePress = Time.time;
            //find the time that passed between when you pressed the button and when you released the button
            if (downTimePress - downTimePressF > 4) 
            {
                //if time is larger than 4 seconds then you are good to go
                buttonSelected = true;
                print("button Pressed"); 
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
        //what happens when you press the highlighted button
        if (downTimePress - downTimePressF > 3)
        {
            if ((buttonSelected == true) && (setButton == 0))
            {
                print("Starting game");
                StartGame();
                buttonSelected = false;
            }
            if ((buttonSelected == true) && (setButton == 1))
            {
                print("Watching credits");
                Credits();
                buttonSelected = false;
            }
            if ((buttonSelected == true) && (setButton == 2))
            {
                print("Murdering game");
                QuitGame();
                buttonSelected = false;
            }
        }
        //to leave the credit menu
        if (Input.GetKeyDown(KeyCode.Alpha1) && (sceneName == Credit))
        {
            print("Back to Menu");
            StartGame();
        }
    }
    // scene changes
    public void StartGame()
    {
        SceneManager.LoadScene(firstLevel);
    }


    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Quittign");
    }

    public void Credits()
    {
        SceneManager.LoadScene(Credit);
    }

    public void menu()
    {
        SceneManager.LoadScene(AntMenu);
    }
}