using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Combat
{
    [CreateAssetMenu(fileName = "PlayerWeapon", menuName = "Weapons/Create Player Weapon", order = 0)]
    public class PlayerWeapon : Weapon
    {
        [SerializeField] private AnimatorOverrideController weaponOverride = null;
        [SerializeField] private GameObject prefab;

        private GameObject weaponInstance;
        public void SpawnWeapon(Transform spawnTransform, Animator animator = null)
        {
            if (prefab != null)
                weaponInstance = Instantiate(prefab, spawnTransform);
            if (animator != null)
                animator.runtimeAnimatorController = weaponOverride;
        }

        public void AnimatorSetTrigger(string trigger)
        {
            weaponInstance.GetComponent<Animator>().SetTrigger(trigger);
        }
    }
}

