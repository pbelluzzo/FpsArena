using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Combat
{
    [RequireComponent(typeof(Health))]
    public abstract class Fighter : MonoBehaviour
    {
        [SerializeField] protected int ammo;

        protected Health health;
        protected float timeSinceLastAttack = 0;

        public void UseAmmo(int ammount) => ammo -= ammount;
        public void AddAmmo(int ammount) => ammo += ammount;
        public void SetAmmo(int ammount) => ammo = ammount;
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
