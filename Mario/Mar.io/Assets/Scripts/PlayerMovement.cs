using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    public float moveSpeed;

    private RaycastHit2D hit;
    public float jumpForce;
    public bool jumping;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        jumping = false;
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");

        rb.AddForce(Vector2.right * horizontal * moveSpeed * Time.deltaTime);

        FlipDirection();

        ChangeAnimations();

        Jump();
    }

    private void ResetJumping()
    {
        jumping = false;
    }

    private void FlipDirection()
    {
        foreach (SpriteRenderer sprite in GetComponentsInChildren<SpriteRenderer>())
        {
            sprite.flipX = rb.velocity.x < 0;
        }
    }

    private void ChangeAnimations()
    {
        foreach (Animator animator in GetComponentsInChildren<Animator>())
        {
            animator.SetFloat("velocityX", rb.velocity.x);
            animator.SetFloat("horizontalInput", Input.GetAxis("Horizontal"));
            animator.SetBool("inAir", hit.collider == null || jumping);
        }
    }

    private void Jump()
    {
        hit = Physics2D.CircleCast(rb.position, .25f, Vector2.down, .375f, LayerMask.GetMask("Default"));

        if (hit.collider != null && Input.GetKeyDown(KeyCode.Space))
        {
            Vector3 velocity = rb.velocity;
            velocity.y = jumpForce;
            rb.velocity = velocity;
            jumping = true;
            Invoke("ResetJumping", .5f);
        }

        if (jumping && Input.GetKey(KeyCode.Space))
        {
            Vector3 velocity = rb.velocity;
            velocity.y = jumpForce;
            rb.velocity = velocity;
        }
    }
}
