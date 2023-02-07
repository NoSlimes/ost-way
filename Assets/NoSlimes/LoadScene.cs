using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NoSlimesJustCats
{
    public class LoadScene : MonoBehaviour
    {
        public void ChangeScene(string sceneName)
        {
            SceneChanger.instance.ChangeScene(sceneName);
        }

        public IEnumerator WaitSeconds(float secondsToWait)
        {
            Debug.Log($"Wating for {secondsToWait} seconds!", this);
            yield return new WaitForSeconds(secondsToWait);
            Debug.Log($"{secondsToWait} seconds have now passed!");
        }
    }
}