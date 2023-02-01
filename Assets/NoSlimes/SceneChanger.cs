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

        public IEnumerator ChangeSceneAsync(string sceneName)
        {
            if (sceneName == SceneManager.GetActiveScene().name) { yield break; }

            loadScreen.SetActive(true);
            AsyncOperation loadSceneOperation = SceneManager.LoadSceneAsync(sceneName);

            while (!loadSceneOperation.isDone)
            {
                float progress = Mathf.Clamp01(loadSceneOperation.progress / .9f);
                loadBar.value = progress;
                yield return null;
            }
            loadScreen.SetActive(false);
        }
    }
}