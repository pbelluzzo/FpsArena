using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Combat;
using Movement;
using Gameplay.ObjectPooling;

namespace Controllers
{
    public class AIController : MonoBehaviour, IPoolObject, IScoreableObject
    {
        [Tooltip("Score given to the player for killing this enemy")]
        [Min(0)]
        [SerializeField] private int score;
        [Tooltip("Object tag from object pooler")]
        [SerializeField] private string poolerTag;
        [SerializeField] private string spawnEffectPoolTag;

        Health health;
        Transform playerTransform;
        AIMover navMeshMover;
        AIFighter navMeshFighter;

        public string GetTag() => poolerTag;
        public int GetScore() => score;
        void Awake()
        {
            playerTransform = PlayerBroadcaster.GetPlayer().transform;
            health = GetComponent<Health>();
            navMeshFighter = GetComponent<AIFighter>();
            navMeshMover = GetComponent<AIMover>();
        }

        public void OnObjectSpawn(GameObject spawnerObj = null)
        {
            ObjectPooler.instance.SpawnFromPool(spawnEffectPoolTag, transform);
            health.SetIsDead(false);
            health.Heal(9999);
            GetComponent<Animator>().Rebind();
        }

        void Update()
        {
            if (health.GetIsDead()) return;
            if (Vector3.Distance(transform.position, playerTransform.position) > navMeshFighter.GetWeapon().GetRange())
            {
                navMeshMover.MoveTo(playerTransform.position);
                return;
            }
            navMeshMover.Stop();
            navMeshFighter.HandleAttack();
        }
    }
}
