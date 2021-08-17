using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Combat
{
    [RequireComponent(typeof(Health))]
    public abstract class Fighter : MonoBehaviour
    {
        [SerializeField] protected int ammo;
        [SerializeField] protected float projectileSpawnOffset;
        [SerializeField] protected Transform projectileSpawnTransform;

        protected Health health;
        protected float timeSinceLastAttack = 0;

        void Start()
        {
            health = GetComponent<Health>();
        }

        private void Update()
        {
            timeSinceLastAttack += Time.deltaTime;
        }

        protected abstract void Attack();

    }

}
