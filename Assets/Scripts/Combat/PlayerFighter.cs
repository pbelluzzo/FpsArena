using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Gameplay;

namespace Combat
{
    public class PlayerFighter : Fighter
    {
        [SerializeField] private PlayerWeapon fighterWeapon;
        [SerializeField] private Transform playerHand;
        [SerializeField] private float projectileSpawnOffset;

        private Transform projectileSpawnTransform;

        public PlayerWeapon GetWeapon() => fighterWeapon;
        void Start()
        {
            projectileSpawnTransform = playerHand;
            projectileSpawnTransform.localPosition = new Vector3(playerHand.localPosition.x, playerHand.localPosition.y, playerHand.localPosition.z + projectileSpawnOffset);

            if (fighterWeapon != null)
               fighterWeapon.SpawnWeapon(playerHand);
        }

        public void HandleAttack()
        {
            if (timeSinceLastAttack < fighterWeapon.GetCooldown())
                return;
            timeSinceLastAttack = 0;
            if (fighterWeapon.GetIsRanged())
            {
                ObjectPooler.instance.SpawnFromPool(fighterWeapon.GetProjectileTag(), playerHand, this.gameObject);
                fighterWeapon.AnimatorSetTrigger("fire");
            }
        }
        protected override void Attack()
        {
            
        }

    }

}
