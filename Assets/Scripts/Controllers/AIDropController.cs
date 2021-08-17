using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Gameplay.ObjectPooling;

public class AIDropController : MonoBehaviour
{
    [SerializeField] private ItemDrop[] itemDrops;
   
    public void HandleDrop()
    {
        foreach(ItemDrop itemDrop in itemDrops)
        {
            if (Random.Range(0,100) <= itemDrop.dropChance)
            {
                ObjectPooler.instance.SpawnFromPool(itemDrop.itemPoolerTag, gameObject.transform);
            }
        }
    }
}
