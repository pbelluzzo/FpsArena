using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Gameplay.ObjectPooling
{
    public class PoolVfx : MonoBehaviour, IPoolObject
    {
        [SerializeField] float destroyTime;
        [SerializeField] string poolTag;
        public string GetTag()
        {
            return poolTag;
        }

        public void OnObjectSpawn(GameObject objectSpawner = null)
        {
            StartCoroutine(ReturnToQueue(destroyTime));
        }

        private IEnumerator ReturnToQueue(float time)
        {
            yield return new WaitForSeconds(time);
            ObjectPooler.instance.EnqueueObject(poolTag, this.gameObject);
            gameObject.SetActive(false);
        }

    }
}

