using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMNG : MonoBehaviour
{
    public Vector3 spawnPos = new Vector3(-128, -64, 0);
    [SerializeField]
    GameObject player;

    void Update()
    {
        if (!FindObjectOfType<Player>()) Instantiate(player, spawnPos, Quaternion.identity);
    }
}
