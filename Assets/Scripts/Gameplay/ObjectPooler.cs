using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Gameplay
{
    public class ObjectPooler : MonoBehaviour
    {
        public static ObjectPooler instance;
        public List<Pool> pools;
        [SerializeField] Dictionary<string, Queue<GameObject>> poolDictionary;

        private void Awake()
        {
            if (instance != null && instance != this)
            {
                Destroy(this.gameObject);
                return;
            }
                instance = this;
        }

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
            if (poolDictionary[tag].Count <= 0)
            {
                Debug.LogWarning("Queue with tag " + tag + " is empty");
                return null;
            }

            GameObject objectToSpawn = poolDictionary[tag].Dequeue();

            objectToSpawn.SetActive(true);
            objectToSpawn.transform.position = spawnPos;
            objectToSpawn.transform.rotation = spawnRot;

            IPoolObject iPoolObject = objectToSpawn.GetComponent<IPoolObject>();
            if (iPoolObject != null)
                iPoolObject.OnObjectSpawn();

            return objectToSpawn;
        }
        public GameObject SpawnFromPool(string tag, Transform spawnTransform)
        {
            if (poolDictionary[tag].Count <= 0)
            {
                Debug.LogWarning("Queue with tag " + tag + " is empty");
                return null;
            }

            GameObject objectToSpawn = poolDictionary[tag].Dequeue();

            objectToSpawn.transform.position = spawnTransform.position;
            objectToSpawn.transform.rotation = spawnTransform.rotation;
            objectToSpawn.SetActive(true);

            IPoolObject iPoolObject = objectToSpawn.GetComponent<IPoolObject>();
            if (iPoolObject != null)
                iPoolObject.OnObjectSpawn();

            return objectToSpawn;
        }
        public GameObject SpawnFromPool(string tag, Transform spawnTransform,  GameObject objectSpawner)
        {
            if (poolDictionary[tag].Count <= 0)
            {
                Debug.LogWarning("Queue with tag " + tag + " is empty");
                return null;
            }

            GameObject objectToSpawn = poolDictionary[tag].Dequeue();

            objectToSpawn.transform.position = spawnTransform.position;
            objectToSpawn.transform.rotation = spawnTransform.rotation;
            objectToSpawn.SetActive(true);

            IPoolObject iPoolObject =  objectToSpawn.GetComponent<IPoolObject>();

            if (iPoolObject != null)
                iPoolObject.OnObjectSpawn( objectSpawner);

            return objectToSpawn;
        }

        public void EnqueueObject(string tag, GameObject objectToEnqueue)
        {
            poolDictionary[tag].Enqueue(objectToEnqueue);
        }      

    }

}
