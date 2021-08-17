using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Core;

namespace Uinterface
{
    public class MainMenu : MonoBehaviour
    {
        [SerializeField] SceneLoader sceneLoader;

        private void Awake()
        {
            sceneLoader = FindObjectOfType<SceneLoader>();
        }
        public void StartGame()
        {
            sceneLoader.LoadScene(2);
        }
    }

}
