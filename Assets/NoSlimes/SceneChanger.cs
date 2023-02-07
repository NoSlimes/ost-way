using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace NoSlimesJustCats
{
    public class SceneChanger : MonoBehaviour
    {
        public static SceneChanger instance;

        [SerializeField] private GameObject loadScreen;
        [SerializeField] private Slider loadBar;

        private bool isLoading = false;

        private void Start()
        {
            if (instance == null)
            {
                instance = this;
            }
            else
            {
                Destroy(gameObject);
            }

            loadScreen.SetActive(false);

            DontDestroyOnLoad(gameObject);
        }

        public void ChangeScene(string sceneName)
        {
            StartCoroutine(ChangeSceneAsync(sceneName));
            isLoading = true;
        }

        private IEnumerator ChangeSceneAsync(string sceneName)
        {
            if (sceneName == SceneManager.GetActiveScene().name) { yield break; }
            if (isLoading) { yield break; }

            loadScreen.SetActive(true);
            loadBar.value = 0f;
            AsyncOperation loadSceneOperation = SceneManager.LoadSceneAsync(sceneName);
            loadSceneOperation.allowSceneActivation = false;

            while (!loadSceneOperation.isDone)
            {
                float progress = Mathf.Clamp01(loadSceneOperation.progress / .9f);
                loadBar.value = progress;
                if(loadSceneOperation.progress >= 0.9f)
                {
                    loadSceneOperation.allowSceneActivation = true;
                }
                yield return null;
            }
            loadScreen.SetActive(false);
            isLoading = false;
        }
    }

}