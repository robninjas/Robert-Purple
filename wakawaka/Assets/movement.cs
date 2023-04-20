using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class movement : MonoBehaviour
{
    abstract protected void ChildUpdate();

    public float speed;
    public Vector2 initialDirection;
    public LayerMask obstacleLayer;

    protected Rigidbody2D rb;
    protected Vector2 direction;
    protected Vector2 nextDirection;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        direction = initialDirection;
        nextDirection = Vector2.zero;
    }

    // Update is called once per frame
    void Update()
    {
        if (nextDirection != Vector2.zero)
        {
            SetDirection(nextDirection);
        }

        ChildUpdate();
    }
    
    private void FixedUpdate() // runs exactly 50 times/second, somehow.
    {
        Vector2 position = rb.position;
        Vector2 translation = direction * speed * Time.fixedDeltaTime;

        rb.MovePosition(position + translation);
    }

    private bool Occupied(Vector2 newDirection)
    {
        RaycastHit2D hit = Physics2D.BoxCast(transform.position, Vector2.zero * .75f, 0f, newDirection, 1.5f, obstacleLayer);
        return hit.collider != null;
    }

    protected void SetDirection(Vector2 newDirection)
    {
        if (!Occupied(newDirection))
        {
            direction = newDirection;
            nextDirection = Vector2.zero;
        }

        else
        {
            nextDirection = newDirection;
        }
    }
}
