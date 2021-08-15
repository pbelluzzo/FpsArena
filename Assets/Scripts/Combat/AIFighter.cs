using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Gameplay;

namespace Combat
{
    public class AIFighter : Fighter
    {
        [SerializeField] private AIWeapon fighterWeapon;
        private Health targetHealth;
        private Animator animator;

        public AIWeapon GetWeapon() => fighterWeapon;

        void Start()
        {
            targetHealth = PlayerBroadcaster.GetPlayer().GetComponent<Health>();
            animator = GetComponent<Animator>();
        }

        public void HandleAttack()
        {
            if (timeSinceLastAttack >= fighterWeapon.GetCooldown())
            {
                Attack();
            }
        }

        protected override void Attack()
        {
            transform.LookAt(targetHealth.transform.position);
            timeSinceLastAttack = 0;
            animator.SetTrigger("attack");

            if (!fighterWeapon.GetIsRanged())
            {
                if (targetHealth.Damage(fighterWeapon.GetDamage()))
                {
                    targetHealth = null;
                }
                return;
            }

            ObjectPooler.instance.SpawnFromPool(fighterWeapon.GetProjectileTag(), transform, this.gameObject);
        }

        // Animation Event
        void Hit()
        {

        }

}
}
