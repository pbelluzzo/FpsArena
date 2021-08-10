using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Core
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField]
        SceneLoader sceneLoader;

        void Start()
        {
            sceneLoader.LoadScene(1);
        }

        void Update()
        {
        
        }
    }
}
