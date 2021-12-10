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
    public GameObject diamond;
    public GameObject StoneDoor;
    public bool preOpenStoneDoor;
    public Transform RespawnPointDiamond;
    public Transform RespawnPointStoneDoor;

    void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private async void OnCollisionEnter2D(Collision2D collision){
        if (gameObject ==null || collision.gameObject == null)
        {
            return;
        }
        
        if(collision.gameObject.tag == "Spikes"){
            IncreaseDeathCountOnCurrentLvl();
            animator.SetBool("dead", true);
            await Task.Delay(100);
            animator.SetBool("dead", false);

            int x = Int32.Parse(PlayerPrefs.GetString("x")); 
            int y = Int32.Parse(PlayerPrefs.GetString("y")); 
            gameObject.transform.position = new Vector2(x,y);

            // Respawn diamond and stone-door on player death
            if(diamond.activeSelf == false){
                diamond.SetActive(true);
            }
            if(preOpenStoneDoor == false){
                StoneDoor.SetActive(true);
            }else{
                StoneDoor.SetActive(false);
            }

        }
        else if(collision.gameObject.tag == "Enemy01"){
            IncreaseDeathCountOnCurrentLvl();
            animator.SetBool("dead", true);
            await Task.Delay(100);
            animator.SetBool("dead", false);

            int x = Int32.Parse(PlayerPrefs.GetString("x")); 
            int y = Int32.Parse(PlayerPrefs.GetString("y")); 
            gameObject.transform.position = new Vector2(x,y);
        }
        
    }

    private void IncreaseDeathCountOnCurrentLvl(){
        int currentLvl = SceneManager.GetActiveScene().buildIndex-1;
        string currentDeathCount = ScoresModel.GetDeath(currentLvl);
        ScoresModel.SetDeath(currentLvl, (Int32.Parse(currentDeathCount)+1).ToString());
    }
}
