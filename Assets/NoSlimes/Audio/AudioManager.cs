using UnityEngine;
using System;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;

    public static AudioManager instance;
    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
        if (instance == null)
            instance = this;
        else
        {
            Destroy(gameObject);
            return;
        }

        foreach (Sound s in sounds)
        {
            Scene currentScene = UnityEngine.SceneManagement.SceneManager.GetActiveScene();
            string sceneName = currentScene.name;
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.outputAudioMixerGroup = s.mixer;
            s.source.clip = s.clip;

            s.source.loop = s.loop;
            s.source.playOnAwake = s.playOnAwake;
            s.source.bypassReverbZones = s.bypassReverbZones;

            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.priority = s.priority;
            s.source.reverbZoneMix = s.reverbZoneMix;
        }

        SceneManager.activeSceneChanged += activeSceneChanged;
    }

    public void Play(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.LogWarning("Sound: \"" + name + "\" was not found!");
            return;
        }
        s.source.Play();
    }

    public void StopAll()
    {
        foreach (Sound sound in sounds)
        {
            sound.source.Stop();
        }
        /*Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.LogWarning("Sound: " + name + "was stopped!");
            return;
        }
        s.source.StopAll();*/
    }

    //Place sounds that you want to play at the start of the game in the Start() function
    private void Start()
    {
        Play("song");
    }

    private void activeSceneChanged(Scene previousScene, Scene changedScene)
    {
        Debug.Log("test", this);
        if (changedScene.name == "OneWayMain")
        {
            StopAll();
            Play("ambience");

            GetComponent<randomAudioPlayer>().StartLoop();


        }
    }

    private void Update()
    {
          
    }

    
}
