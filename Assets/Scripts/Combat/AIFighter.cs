using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Gameplay.ObjectPooling;

namespace Combat
{
    public class AIFighter : Fighter, IUseTarget, IUseWeapon
    {
        [SerializeField] private AIWeapon fighterWeapon;
        [SerializeField] private string hitEffectPoolTag;
        private Health targetHealth;
        private Animator animator;

        public Weapon GetWeapon() => fighterWeapon;

        public Transform GetTarget() => targetHealth.gameObject.transform;

        void Start()
        {
            targetHealth = PlayerBroadcaster.GetPlayer().GetComponent<Health>();
            animator = GetComponent<Animator>();
        }

        public void HandleAttack()
        {
            if (!targetHealth.GetIsDead() && timeSinceLastAttack >= fighterWeapon.GetCooldown())
            {
                Attack();
            }
        }

        protected override void Attack()
        {
            if (targetHealth.GetIsDead())
            {
                return;
            }

            transform.LookAt(targetHealth.transform.position);
            timeSinceLastAttack = 0;
            animator.SetTrigger("attack");

            if (!fighterWeapon.GetIsRanged())
            {
                targetHealth.Damage(fighterWeapon.GetDamage());
                return;
            }

            ObjectPooler.instance.SpawnFromPool(fighterWeapon.GetProjectileTag(), projectileSpawnTransform, this.gameObject);
        }

        // Animation Event
        void Hit()
        {
            ObjectPooler.instance.SpawnFromPool(hitEffectPoolTag, targetHealth.transform);
        }

}
}
