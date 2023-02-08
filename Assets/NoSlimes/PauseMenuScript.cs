using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

namespace NoSlimesJustCats
{
    public class PauseMenuScript : MonoBehaviour
    {
        private Volume volume;
        [SerializeField] private GameObject pauseMenuPanel;
        [SerializeField] private float defaultTimeScale = 1;
        public static bool isPaused;

        private void Start()
        {
            volume = GetComponentInChildren<Volume>();

            if (!checkPaused())
            {
                Pause();
            }
        }

        private bool pressedPause()
        {
            if (Input.GetButtonDown("Button"))
            {
                return true;
            }
            else return false;
        }

        private bool checkPaused()
        {
            if (pauseMenuPanel.activeSelf)
            {
                return true;
            }
            else return false;
        }

        private void Update()
        {
            if (pressedPause())
            {
                if (checkPaused())
                {
                    Unpause();
                }
                //else Pause();

            }
        }

        private void Pause()
        {
            Time.timeScale = 0;
            pauseMenuPanel.SetActive(true);
            volume.enabled = true;
            isPaused = true;
        }

        private void Unpause()
        {
            Time.timeScale = defaultTimeScale;
            pauseMenuPanel.SetActive(false);
            volume.enabled = false;
            isPaused = false;
        }

    }
}
