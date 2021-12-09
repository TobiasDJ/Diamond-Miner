using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using Debug = UnityEngine.Debug;
using UnityEngine.SceneManagement;

public class PlayerDeath : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision){
        if(collision.gameObject.tag == "Spikes"){
            IncreaseDeathCountOnCurrentLvl();
            Destroy(gameObject);

            LevelManager.instance.Respawn();

        }

        if(collision.gameObject.tag == "Enemy01"){
            IncreaseDeathCountOnCurrentLvl();
            Destroy(gameObject);
            LevelManager.instance.Respawn();
        }
        
    }

    private void IncreaseDeathCountOnCurrentLvl(){
        int currentLvl = SceneManager.GetActiveScene().buildIndex-1;
        string currentDeathCount = ScoresModel.GetDeath(currentLvl);
        ScoresModel.SetDeath(currentLvl, (Int32.Parse(currentDeathCount)+1).ToString());
    }
}
