using UnityEngine;

namespace Gameplay.ObjectPooling
{
    public interface IPoolObject
    {
        void OnObjectSpawn(GameObject objectSpawner = null);

        string GetTag();
    }

}
