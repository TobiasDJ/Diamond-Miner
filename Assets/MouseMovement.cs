using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vector2 = UnityEngine.Vector2;


public class MouseMovement : MonoBehaviour
{
    public float movementSpeed;
    public float jumpForce = 20f;
    public Transform feet;
    public Rigidbody2D rb;
    public LayerMask groundLayers;
    float mx;
    public bool moveWithMouse;

    public AudioClip jumpAudio;
    public AudioClip respawnAudio;
    public AudioClip ouchAudio;

    SpriteRenderer spriteRenderer;
    internal Animator animator;
    /*internal new*/
    public AudioSource audioSource;

    /*float distance_to_screen;
    Vector3 pos_move;
    Vector3 old_position;*/

    Vector3 old_position = new Vector3(1, 3, 1);

    public float speed = 1.5f;
    private Vector3 target;

    void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        animator.SetBool("dead", false);
    }

    void Start()
    {
        target = old_position;
    }

    private void Update()
    {
        if (moveWithMouse == true)
        {
            if (Input.GetMouseButtonDown(0))
            {
                target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                target.z = transform.position.z;
                transform.position = Vector3.MoveTowards(transform.position, target, speed * 1000);

            }
            //transform.position = Vector3.MoveTowards(transform.position, target, speed);
        }
        else
        {
            mx = Input.GetAxisRaw("Horizontal");
        }



        if (Input.GetAxisRaw("Jump") == 1 && IsGrounded())
        {
            Jump();
        }
        if (Mathf.Abs(mx) > 0.05f)
        {
            animator.SetBool("isRunning", true);
        }
        else
        {
            animator.SetBool("isRunning", false);
        }
        if (mx > 0f)
        {
            transform.localScale = new Vector3(2f, 2f, 2f);
        }
        else if (mx < 0f)
        {
            transform.localScale = new Vector3(-2f, 2f, 2f);
        }

        animator.SetBool("isGrounded", IsGrounded());
    }

    public void FixedUpdate()
    {
        Vector2 movement = new Vector2(mx * movementSpeed, rb.velocity.y);
        rb.velocity = movement;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy01") || other.CompareTag("Spikes") || other.CompareTag("Ground"))
        {
            transform.position = Vector3.MoveTowards(old_position, target, speed);
        }

    }

    public void Jump()
    {
        Vector2 movement = new Vector2(rb.velocity.x, jumpForce);
        rb.velocity = movement;
    }

    public bool IsGrounded()
    {
        Collider2D groundCheck = Physics2D.OverlapCircle(feet.position, 0.5f, groundLayers);
        if (groundCheck != null)
        {
            return true;
        }
        return false;
    }
}
