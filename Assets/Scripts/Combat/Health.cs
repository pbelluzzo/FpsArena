using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Gameplay;

namespace Combat
{
    public class Health : MonoBehaviour, ICanDie
    {
        [Tooltip("Character's current health")]
        [SerializeField] private int health = 100;
        [Range(1,1000)]
        [SerializeField] private int maxHealth = 100;

        [SerializeField] private bool isPoolObject;
        [SerializeField] private string poolTag;

        private bool isDead = false;
        private Animator animator;
        [Space(15)]
        public UnityEvent dieEvent;
        private void OnValidate() => health = Mathf.Clamp(health, 0, maxHealth);
        public void SetIsDead(bool value) => isDead = value;
        public bool GetIsDead() => isDead;

        private void Awake()
        {
            animator = GetComponent<Animator>();
        }

        public bool Heal(int value)
        {
            health = Mathf.Clamp(health + value, 0, maxHealth);
            return CheckDeath();
        }

        public bool Damage(int value)
        {
            health = Mathf.Clamp(health - value, 0, maxHealth);
            return CheckDeath();
        }

        private bool CheckDeath()
        {
            if (health <= 0)
            {
                Die();
                return true;
            }
            return false;
        }

        public void Die()
        {
            dieEvent.Invoke();
            isDead = true;

            if (isPoolObject)
                ReturnToQueue();
        }

        private void ReturnToQueue()
        {
            ObjectPooler.instance.EnqueueObject(poolTag, this.gameObject);
        }
    }

}
