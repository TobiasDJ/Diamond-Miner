using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using Debug = UnityEngine.Debug;
using UnityEngine.SceneManagement;
using System.Threading.Tasks;

public class PlayerDeath : MonoBehaviour
{
    internal Animator animator;
    void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private async void OnCollisionEnter2D(Collision2D collision){
        if(collision.gameObject.tag == "Spikes"){
            IncreaseDeathCountOnCurrentLvl();
            animator.SetBool("dead", true);

            await Task.Delay(200);
            Destroy (gameObject);  
            
            LevelManager.instance.Respawn();
        }

        if(collision.gameObject.tag == "Enemy01"){
            IncreaseDeathCountOnCurrentLvl();
            animator.SetBool("dead", true);

            await Task.Delay(200);
            Destroy (gameObject); 

            LevelManager.instance.Respawn();
        }
        
    }

    private void IncreaseDeathCountOnCurrentLvl(){
        int currentLvl = SceneManager.GetActiveScene().buildIndex-1;
        string currentDeathCount = ScoresModel.GetDeath(currentLvl);
        ScoresModel.SetDeath(currentLvl, (Int32.Parse(currentDeathCount)+1).ToString());
    }
}
