using UnityEngine;

[CreateAssetMenu(fileName = "Weapon", menuName = "Weapons/Create Weapon", order = 0)]
public class Weapon : ScriptableObject
{
    private AnimatorOverrideController weaponOverride = null;
    private GameObject prefab;
    [Min(0)]
    private int damage;
    [Min(0)]
    private int range;
    public int GetDamage() => damage;
    public int GetRange() => range;

    public void SpawnWeapon(Transform spawnTransform, Animator animator = null)
    {
        Instantiate(prefab, spawnTransform);
        if (prefab != null)
            Instantiate(prefab, spawnTransform);
        if (animator != null)
            animator.runtimeAnimatorController = weaponOverride;
    }
}
