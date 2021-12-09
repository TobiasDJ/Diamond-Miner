using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeath : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision){
        if(collision.gameObject.tag == "Spikes"){
            Destroy(gameObject);

            LevelManager.instance.Respawn();

        }

        if(collision.gameObject.tag == "Enemy01"){
            Destroy(gameObject);
            LevelManager.instance.Respawn();
        }
        
    }
}
