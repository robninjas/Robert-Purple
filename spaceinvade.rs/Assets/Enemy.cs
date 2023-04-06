using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Animator animator;
    static public Vector2 direction;
    public float speed = .01f;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        direction = Vector2.right;
    }

    private void Update()
    {
        transform.Translate(direction * Time.deltaTime * speed);

        if (transform.position.x > 8f)
        {
            direction = Vector2.left;
            MoveDown();
        }

        if (transform.position.x < -8f)
        {
            direction = Vector2.right;
            MoveDown();
        }
    }

    private void MoveDown()
    {
        foreach (Enemy enemy in FindObjectsOfType(typeof(Enemy)))
        {
            enemy.transform.Translate(Vector2.down * speed);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        animator.SetTrigger("Death");
        Destroy(gameObject, 1f);
        Destroy(collision.gameObject);
    }
}
