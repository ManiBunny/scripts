using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class movement_player : MonoBehaviour
{
    private bool isGrounded= true;
    private Rigidbody2D rb;
    float horizontal;
    public float moveSpeed = 15f;
    public float jumpAmount = 10;
    public Animator animator;
    public SpriteRenderer sprite;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }


    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(horizontal * moveSpeed, rb.velocity.y);
        animator.SetFloat("speed", Mathf.Abs(horizontal *moveSpeed));
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(Vector2.up * jumpAmount, ForceMode2D.Impulse);
            isGrounded = false;
        }
        if (horizontal < 0)
        {
            sprite.flipX = true;
        }
        if(horizontal > 0)
        {
            sprite.flipX = false;
        }

    }
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "ground" && isGrounded == false)
        {
            isGrounded = true;
        }
    }
}