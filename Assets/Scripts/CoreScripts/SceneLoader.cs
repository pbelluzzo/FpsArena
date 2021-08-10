using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Core
{
    public class SceneLoader : MonoBehaviour
    {
        public void LoadScene(int sceneNumber)
        {
            SceneManager.LoadScene(sceneNumber);
        }
    }

}
