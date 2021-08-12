using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Gameplay
{
    public class ObjectPooler : MonoBehaviour
    {
        public List<Pool> pools;
        [SerializeField] Dictionary<string, Queue<GameObject>> poolDictionary;
        void Start()
        {
            poolDictionary = new Dictionary<string, Queue<GameObject>>();

            foreach (Pool pool in pools)
            {
                Queue<GameObject> objectPool = new Queue<GameObject>();

                for  (int i = 0; i < pool.size; i++)
                {
                    GameObject obj = Instantiate(pool.prefab);
                    obj.SetActive(false);
                    objectPool.Enqueue(obj);
                }

                poolDictionary.Add(pool.tag, objectPool);
            }
        }

        public GameObject SpawnFromPool(string tag, Vector3 spawnPos, Quaternion spawnRot)
        {
            if (!poolDictionary.ContainsKey(tag)) return null;

            GameObject objectToSpawn = poolDictionary[tag].Dequeue();

            objectToSpawn.SetActive(true);
            objectToSpawn.transform.position = spawnPos;
            objectToSpawn.transform.rotation = spawnRot;

            IPoolObject iPoolObject = GetComponent<IPoolObject>();
            if (iPoolObject != null)
                iPoolObject.OnObjectSpawn(this);

            return objectToSpawn;
        }

        public GameObject SpawnFromPool(string tag, Transform spawnTransform)
        {
            if (!poolDictionary.ContainsKey(tag)) return null;

            GameObject objectToSpawn = poolDictionary[tag].Dequeue();

            objectToSpawn.SetActive(true);
            objectToSpawn.transform.position = spawnTransform.position;
            objectToSpawn.transform.rotation = spawnTransform.rotation;

            IPoolObject iPoolObject = GetComponent<IPoolObject>();
            if (iPoolObject != null)
                iPoolObject.OnObjectSpawn(this);

            return objectToSpawn;
        }

        public void EnqueueObject(string tag, GameObject objectToEnqueue)
        {
            poolDictionary[tag].Enqueue(objectToEnqueue);
        }      

    }

}
