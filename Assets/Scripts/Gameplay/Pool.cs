using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Gameplay
{
    [System.Serializable]
    public class Pool
    {
        public string tag;
        public int size;
        public GameObject prefab;

        public Pool(string poolTag, int poolSize, GameObject poolPrefab)
        {
            tag = poolTag;
            size = poolSize;
            prefab = poolPrefab;
        }
    }
}
