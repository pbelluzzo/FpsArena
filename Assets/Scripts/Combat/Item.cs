using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Gameplay.ObjectPooling;

namespace Combat
{
    public class Item : MonoBehaviour, IPoolObject
    {
        [SerializeField] private ItemEffect[] itemEffects;
        [SerializeField] AudioClip effectSound;
        [SerializeField] string poolTag;
        [SerializeField] string particleEffectTag;

        public string GetTag() => poolTag;

        public void OnObjectSpawn(GameObject objectSpawner = null)
        {
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                if (particleEffectTag != "")
                    ObjectPooler.instance.SpawnFromPool(particleEffectTag, other.transform);

                foreach (ItemEffect itemEffect in itemEffects)
                {
                    itemEffect.ApplyEffect(other.gameObject);
                }

                ObjectPooler.instance.EnqueueObject(poolTag, gameObject);
                gameObject.SetActive(false);
            }

        }
    }

}
