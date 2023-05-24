using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NMEmovement : MonoBehaviour
{

    public float speed = 2f;
    public Vector2 direction = Vector2.left;
    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnBecameVisible()
    {
        Debug.Log("visnle");
        rb.velocity = direction * speed;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
