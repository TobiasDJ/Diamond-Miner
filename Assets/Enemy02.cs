using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;

public class Enemy02 : MonoBehaviour
{
    public Animator animator;

    void Awake()
    {
        animator = GetComponent<Animator>();
    }

     public async void OnCollisionEnter2D(Collision2D collision)
        {
            animator.SetBool("attackRight", true);
            await Task.Delay(200);
            animator.SetBool("attackRight", false);
            animator.SetBool("attackLeft", true);
            await Task.Delay(200);
              animator.SetBool("attackRight", false);
            animator.SetBool("attackLeft", false);
        } 
}
