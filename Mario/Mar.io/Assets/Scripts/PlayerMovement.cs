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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        float distance = .375f;

        if (GetComponent<PlayerBehaviour>().big)
        {
            distance += 1f;
        }
        RaycastHit2D hitTop = Physics2D.CircleCast(rb.position, .25f, Vector2.up, distance, LayerMask.GetMask("Default"));

        if (hitTop.collider != null)
        {
            Vector3 velocity = rb.velocity;
            velocity.y = 0;
            rb.velocity = velocity;
            jumping = false;

            BlockHit blockHit = hitTop.collider.gameObject.GetComponent<BlockHit>();

            if (blockHit != null)
            {
                blockHit.Hit();
            }
        }



    }

    private void haha(GameObject c)
    {
        c.GetComponent<BoxCollider2D>().enabled = false;
        c.GetComponent<CircleCollider2D>().enabled = true;
        c.gameObject.GetComponent<SpriteRenderer>().sprite = c.gameObject.GetComponent<BlockHit>().emptyBlock;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("FakeBlock"))
        {
            haha(collision.gameObject);

            foreach (GameObject obj in collision.gameObject.GetComponent<FakeBlock>().blocks)
            {
                haha(obj);
            }
        }
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
