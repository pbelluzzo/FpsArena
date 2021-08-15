using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Combat;
using Movement;

namespace Controllers
{
    public class AIController : MonoBehaviour, IPoolObject
    {
        [SerializeField] private GameObject armor;

        Health health;
        Transform playerTransform;
        AIMover navMeshMover;
        AIFighter navMeshFighter;
        void Awake()
        {
            playerTransform = PlayerBroadcaster.GetPlayer().transform;
            health = GetComponent<Health>();
            navMeshFighter = GetComponent<AIFighter>();
            navMeshMover = GetComponent<AIMover>();
            ChangeArmorTexture();
        }

        public void OnObjectSpawn(GameObject spawnerObj = null)
        {
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

        private void ChangeArmorTexture()
        {
            //armor.GetComponent<Material>().mainTexture = type.texture;
        }
    }

}
