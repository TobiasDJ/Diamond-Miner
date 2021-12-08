using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static LevelManager instance;
    public Transform respawnPoint;
    public GameObject playerPrefab;

    public void Respawn(){
        Instantiate(playerPrefab, respawnPoint.position, Quaternion.identity);
    }

    public void Awake(){
        instance = this;
    }
}
