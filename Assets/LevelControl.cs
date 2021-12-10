using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

using UnityEngine.SceneManagement;

public class LevelControl : MonoBehaviour
{   


   void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // final stage
            if(SceneManager.GetActiveScene().buildIndex == 8){
                MongoDbStorage storage = new MongoDbStorage();
                int totalScore = 0;
                int lvls = 8;
                int death_multiply = 100;
                int sec_multyply = 10;
                for (int i = 0; i<lvls; i++){
                    totalScore += Int32.Parse(ScoresModel.GetDeath(i))*death_multiply;
                    totalScore += Int32.Parse(ScoresModel.GetTime(i))*sec_multyply;
                }
                string name = PlayerPrefs.GetString("PLAYER_NAME");
                Debug.Log($"Name is {name}, score is : {totalScore}");
                var postModel = new HiscoreModel( PlayerPrefs.GetString("PLAYER_NAME"), totalScore);
                storage.AddOrUpdate(postModel);
                SceneManager.LoadScene(0);
            }
            Debug.Log($"Going into lvl : {SceneManager.GetActiveScene().buildIndex}");

            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex +1);
            Debug.Log("Level switch to: " + SceneManager.GetActiveScene().buildIndex.ToString());
        }
    }
}
