using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vector2 = UnityEngine.Vector2;


public class PlayerMovement : MonoBehaviour
{
    public float movementSpeed;
    public float jumpForce = 20f;
    public Transform feet;
    public Rigidbody2D rb;
    public LayerMask groundLayers;
    float mx;

    public AudioClip jumpAudio;
    public AudioClip respawnAudio;
    public AudioClip ouchAudio;

    SpriteRenderer spriteRenderer;
    internal Animator animator;
    /*internal new*/ public AudioSource audioSource;

    void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }

    private void Update(){
        mx = Input.GetAxisRaw("Horizontal");

        if(Input.GetButtonDown("Jump") && IsGrounded()){
            Jump();
        }
        if(Mathf.Abs(mx) > 0.05f){
            animator.SetBool("isRunning", true);
        }else{
            animator.SetBool("isRunning", false);
        }
        if(mx > 0f){
            transform.localScale = new Vector3(2f, 2f, 2f);
        }else if(mx < 0f){
            transform.localScale = new Vector3(-2f, 2f, 2f);
        }
        
        animator.SetBool("isGrounded", IsGrounded());
    }

    public void FixedUpdate(){
        Vector2 movement = new Vector2(mx * movementSpeed, rb.velocity.y);
        rb.velocity = movement;
    }

    public void Jump(){
        Vector2 movement = new Vector2(rb.velocity.x, jumpForce);
        rb.velocity = movement;
    }

    public bool IsGrounded(){
        Collider2D groundCheck = Physics2D.OverlapCircle(feet.position, 0.5f, groundLayers);
        if(groundCheck != null){
            return true;
        }
        return false;
    }
}
