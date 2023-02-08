using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class randomAudioPlayer : MonoBehaviour
{
    [SerializeField] private float minTime = 45f;
    [SerializeField] private float maxTime = 120f;
    [SerializeField] private bool forceMaxTime = false;
    [SerializeField] private bool startOnAwake = false;

    private void Start()
    {
        if(!startOnAwake) { return; }
        StartCoroutine(SoundLoop(minTime, maxTime, forceMaxTime));

        SceneManager.activeSceneChanged += SceneChanged;
    }

    public void StartLoop()
    {
        StartCoroutine(SoundLoop(minTime, maxTime, forceMaxTime));
    }

    public void SceneChanged(Scene prevScene, Scene newScene)
    {
        /*if(newScene.name == "MainMenu" || newScene.name == "Credits")
        {
            StopCoroutine(SoundLoop(0, 0, false));
        }*/
        StopCoroutine(SoundLoop(0, 0, false));
    }

    private IEnumerator SoundLoop(float minTime, float maxTime, bool forceMaxTime)
    {
        while (true)
        {

            if (forceMaxTime)
            {
                yield return new WaitForSecondsRealtime(maxTime);
            }
            else
            {
                yield return new WaitForSecondsRealtime(Random.Range(minTime, maxTime));
            }

            switch (Random.Range(0, 4))
            {
                case 1:
                    AudioManager.instance.Play("sound1");
                    Debug.Log("1", this);
                    break;
                case 2:
                    AudioManager.instance.Play("mouseDead");
                    Debug.Log("2", this);
                    break;
                case 3:
                    AudioManager.instance.Play("sound2");
                    Debug.Log("3", this);
                    break;
                case 4:
                    AudioManager.instance.Play("sound3");
                    Debug.Log("4", this);
                    break;
            }
            
        }
    }
}
