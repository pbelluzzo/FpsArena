using Gameplay;
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

        private Rigidbody projectileRigidbody;
        private bool isMoving = true;
        private float damage;

        public void OnObjectSpawn(GameObject spawnerObject)
        {
            damage = (damageFactor * spawnerObject.GetComponent<PlayerFighter>().GetWeapon().GetDamage());
            projectileRigidbody.velocity = Vector3.zero;
            projectileRigidbody.AddForce(transform.forward * speed);
        }
        
        void Awake()
        {
             projectileRigidbody = GetComponent<Rigidbody>();
        }

        private void OnTriggerEnter(Collider other)
        {

            Health health = other.gameObject.GetComponent<Health>();


            if (health != null)
            {
                Debug.Log("Causing Damage");
                health.Damage(Mathf.RoundToInt(damage));
            }
                isMoving = false;
                ObjectPooler.instance.EnqueueObject(poolTag, this.gameObject);
                gameObject.SetActive(false);
        }

    }

}
