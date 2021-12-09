using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Debug = UnityEngine.Debug;
using UnityEngine.SceneManagement;

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

    public void Update(){
        if(Input.GetKeyDown(KeyCode.Escape)){
            ScoresModel.ResetLocals();
            SceneManager.LoadScene(0);
        }
    }
}
