using Gameplay.ObjectPooling;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Combat
{
    public class Projectile : MonoBehaviour, IPoolObject
    {
        [SerializeField] float speed;
        [Tooltip("Damage factor multiplies the weapon damage")]
        [Min(0)]
        [SerializeField] float damageFactor = 1;
        [Tooltip("Projectile tag in the Object Pooler")]
        [SerializeField] string poolTag;
        [SerializeField] bool followTarget;
        [Min (0.1f)]
        [SerializeField] float lifeTime;
        [SerializeField] string hitEffectPoolTag;

        private GameObject spawnerObject;
        private Transform target;
        private Rigidbody projectileRigidbody;
        private float damage;

        public string GetTag() => poolTag;
        public void OnObjectSpawn(GameObject spawnerObject)
        {
            this.spawnerObject = spawnerObject;
            damage = (damageFactor * spawnerObject.GetComponent<IUseWeapon>().GetWeapon().GetDamage());
            projectileRigidbody.velocity = Vector3.zero;
            if (!followTarget)
            {
                projectileRigidbody.AddForce(transform.forward * speed);
                StartCoroutine(ReturnToQueue());
            }
        }
        
        void Awake()
        {
             projectileRigidbody = GetComponent<Rigidbody>();
        }

        private void Update()
        {
            if (followTarget && spawnerObject.GetComponent<IUseTarget>() != null)
            {
                target = spawnerObject.GetComponent<IUseTarget>().GetTarget();
                transform.LookAt(target);
                transform.Translate(Vector3.forward * (speed / 100) * Time.deltaTime);
            }
        }

        private IEnumerator ReturnToQueue()
        {
            yield return new WaitForSeconds(lifeTime);

            ObjectPooler.instance.EnqueueObject(poolTag, this.gameObject);
            gameObject.SetActive(false);
        }

        private void OnTriggerEnter(Collider other)
        {
            if (followTarget && target.gameObject != other.gameObject)
                return;

            if (other.gameObject.CompareTag("Projectile"))
                return;

            ObjectPooler.instance.SpawnFromPool(hitEffectPoolTag, transform);

            Health health = other.gameObject.GetComponent<Health>();

            if (health != null)
            {
                Debug.Log("Causing Damage");
                health.Damage(Mathf.RoundToInt(damage));
            }

            StopCoroutine(ReturnToQueue());
            ObjectPooler.instance.EnqueueObject(poolTag, this.gameObject);
            gameObject.SetActive(false);
        }

    }

}
