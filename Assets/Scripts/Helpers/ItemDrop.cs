using UnityEngine;

[System.Serializable]
public class ItemDrop
{
    [SerializeField] public string itemPoolerTag;
    [Range(0, 100)] [Tooltip("Drop chance Percentage")]
    [SerializeField] public float dropChance;
}
