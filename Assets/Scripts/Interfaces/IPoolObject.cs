using UnityEngine;
using Gameplay;

public interface IPoolObject
{
    void OnObjectSpawn(GameObject objectSpawner = null);
}
