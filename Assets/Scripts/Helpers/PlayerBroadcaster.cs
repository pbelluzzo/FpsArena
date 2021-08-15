using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBroadcaster : MonoBehaviour
{
    public static PlayerBroadcaster instance;

    [SerializeField] private GameObject player;
    void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
            return;
        }
        instance = this;      
    }

    public static GameObject GetPlayer()
    {
        return instance.player;
    }
}
