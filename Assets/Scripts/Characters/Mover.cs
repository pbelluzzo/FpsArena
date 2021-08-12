using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Characters
{
    public abstract class Mover : MonoBehaviour
    {
        [Header("Movement Control")]

        [Min(0)]
        [SerializeField] protected float characterSpeed = 1;

        [SerializeField] protected bool canRun;
        [Min(1)]
        [SerializeField] protected float runMultiplier = 1.5f;
        protected bool running = false;

        public abstract void SetRunning(bool isRunning);
    }

}
