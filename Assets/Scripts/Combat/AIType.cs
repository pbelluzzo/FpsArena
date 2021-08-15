using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Combat
{
    [CreateAssetMenu(fileName = "AI Type", menuName = "AI/Create new AI", order = 0)]
    public class AIType : ScriptableObject
    {
        public Texture texture;
        [Min(0)]
        public int damage;
        [Min(0)]
        public float attackCooldown;
        [Min(0)]
        public int range;
        public bool isRanged;
        [HideInInspector][Tooltip("Tag used in the object pooler")]
        public string projectileTag;
    }
}
