using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Gameplay.ObjectPooling;
using TMPro;

namespace Combat
{
    public class PlayerFighter : Fighter, IUseWeapon, IUseAmmo
    {
        [SerializeField] private PlayerWeapon fighterWeapon;
        [SerializeField] private TextMeshProUGUI ammoText;

        public void AddAmmo(int value)
        {
            ammo += value;
            ammoText.text = ammo.ToString();
        }
        public void UseAmmo()
        {
            ammo--;
            ammoText.text = ammo.ToString();
        }
        public Weapon GetWeapon() => fighterWeapon;
        void Start()
        {
            if (fighterWeapon != null)
               fighterWeapon.SpawnWeapon(projectileSpawnTransform);

            ammoText.text = ammo.ToString();
        }

        public void HandleAttack()
        {
            if (timeSinceLastAttack < fighterWeapon.GetCooldown())
                return;

            if (ammo < 1)
                return;

            timeSinceLastAttack = 0;
            UseAmmo();
            if (fighterWeapon.GetIsRanged())
            {
                ObjectPooler.instance.SpawnFromPool(fighterWeapon.GetProjectileTag(), projectileSpawnTransform, this.gameObject);
                fighterWeapon.AnimatorSetTrigger("fire");
            }
        }
        protected override void Attack()
        {
            
        }

    }

}
