using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Combat
{
    public class Health : MonoBehaviour, ICanDie
    {
        [Tooltip("Character's current health")]
        [SerializeField] private int health = 100;
        private void OnValidate() => health = Mathf.Clamp(health, 0, maxHealth);

        [Range(1,1000)]
        [SerializeField] private int maxHealth = 100;

        [SerializeField] AudioClip dieSfx;

        public bool isPlayer = false;
        [Space(15)]
        [HideInInspector]
        public UnityEvent dieEvent;
        public void AddHealth(int value)
        {
            health = Mathf.Clamp(health + value, 0, maxHealth);
            CheckHealth();
        }

        private void CheckHealth()
        {
            if (health <= 0) Die();
        }

        public void Die()
        {
            if (dieSfx != null) ; //audioManager.PlayAudio(dieSfx);

            if (isPlayer)
            {
                
            }
        }
    }

}
