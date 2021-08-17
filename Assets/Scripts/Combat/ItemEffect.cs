using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Combat
{
    [CreateAssetMenu(fileName = "Item Effect", menuName = "Item Effects/ Create Item Effect", order = 0)]
    public class ItemEffect : ScriptableObject
    {
        enum EffectType {Heal, Damage, AddAmmo };
        [SerializeField] EffectType effectType;

        [Tooltip("Value of the effect to be applied")]
        [SerializeField] int effectValue;

        public void ApplyEffect(GameObject player)
        {
            if (effectType == EffectType.Heal)
            {
                player.GetComponent<Health>().Heal(effectValue);
                return;
            }
            if (effectType == EffectType.Damage)
            {
                player.GetComponent<Health>().Damage(effectValue);
                return;
            }
            if (effectType == EffectType.AddAmmo)
            {
                player.GetComponent<IUseAmmo>().AddAmmo(effectValue);
                return;
            }
        }
    }

}
