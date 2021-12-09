using System.Collections;
using System.Collections.Generic;
using UnityEngine;
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
            animator.SetBool("dead", true);

            await Task.Delay(100);
            Destroy (gameObject);  
            
            LevelManager.instance.Respawn();
        }

        if(collision.gameObject.tag == "Enemy01"){
            animator.SetBool("dead", true);

            await Task.Delay(100);
            Destroy (gameObject); 

            LevelManager.instance.Respawn();
        }
        
    }
}
