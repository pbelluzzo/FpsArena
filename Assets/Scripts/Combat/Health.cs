using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Gameplay.ObjectPooling;
using Gameplay.DataManagement;

namespace Combat
{
    public class Health : MonoBehaviour, ICanDie
    {
        [Tooltip("Character's current health")]
        [SerializeField] private int health = 100;
        [Range(1,1000)]
        [SerializeField] private int maxHealth = 100;

        [SerializeField] HealthBar healthBar;

        private bool isPoolObject;
        private bool isScoreableObject;
        private string poolTag;
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

            if (healthBar != null)
                healthBar.SetMaxHealth(maxHealth);

            UpdateHealthBar();

            if (GetComponent<IPoolObject>() != null)
            {
                isPoolObject = true;
                poolTag = GetComponent<IPoolObject>().GetTag();
            }

            if (GetComponent<IScoreableObject>() != null)
            {
                isScoreableObject = true;
            }
        }

        // Heals the health and return true if it is still alive
        public bool Heal(int value)
        {
            health = Mathf.Clamp(health + value, 0, maxHealth);
            UpdateHealthBar();
            return CheckDeath();
        }

        // Damages the health and return true if it is still alive
        public bool Damage(int value)
        {
            health = Mathf.Clamp(health - value, 0, maxHealth);
            UpdateHealthBar();
            return CheckDeath();
        }

        private void UpdateHealthBar()
        {
            if (healthBar != null)
                healthBar.SetHealth(health);
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
            if (isDead) 
                return;

            dieEvent.Invoke();
            isDead = true;

            if (isPoolObject)
                StartCoroutine(ReturnToQueue(2));
            if (isScoreableObject)
            {
                SessionDataManager.instance.AddKill();
                SessionDataManager.instance.AddScore(GetComponent<IScoreableObject>().GetScore());
            }
            
        }

        private IEnumerator ReturnToQueue(float time)
        {
            yield return new WaitForSeconds(time);
            ObjectPooler.instance.EnqueueObject(poolTag, this.gameObject);
        }
    }

}
