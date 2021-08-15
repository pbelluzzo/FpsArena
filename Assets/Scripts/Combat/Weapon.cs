using UnityEngine;


namespace Combat
{
    public abstract class Weapon : ScriptableObject
    {
        [Min(0)]
        [SerializeField] protected int damage;
        [Min(0)]
        [SerializeField] protected float range;
        [Min(0)]
        [SerializeField] protected float cooldown;

        [SerializeField] protected bool isRanged;
        [Tooltip("Projectile tag from Object Pooler")] 
        [SerializeField] protected string projectileTag;

        public int GetDamage() => damage;
        public float GetRange() => range;
        public float GetCooldown() => cooldown;
        public bool GetIsRanged() => isRanged;
        public string GetProjectileTag() => projectileTag;
    }
}
