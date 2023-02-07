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
    }
}