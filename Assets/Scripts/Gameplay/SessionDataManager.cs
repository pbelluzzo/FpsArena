using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Gameplay.DataManagement
{
    public class SessionDataManager : MonoBehaviour
    {
        private int score;
        private int kills;

        public static SessionDataManager instance;
        public void AddKill() => kills++;
        public void AddScore(int value) => score += value;
        public int GetScore() => score;
        public int GetKills() => kills;

        private void Awake()
        {
            if (instance != null && instance != this)
            {
                Destroy(this.gameObject);
                return;
            }
            instance = this;
        }
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }
    }

}
