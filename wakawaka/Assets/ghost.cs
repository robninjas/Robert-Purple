using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ghost : movement
{
    public GameObject body;
    public GameObject eyes;
    public GameObject blue;
    public GameObject white;
    public bool atHome;
    public float homeDuration;

    private bool frightened;

    private int counter;

    private void Awake()
    {
        
    }

    protected override void ChildUpdate()
    {

    }

    protected override void FixedChild()
    {
        //counter += 1;
        //Debug.Log(counter);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.gameObject.name);

        node _node = collision.GetComponent<node>();

        if (_node != null)
        {
            int index = Random.Range(0, _node.availableDirections.Count);

            SetDirection(_node.availableDirections[index]);
        }
    }

    private void LeaveHome()
    {

    }

    public void Frighten()
    {

    }

    private void Flash()
    {

    }

    private void Reset()
    {
        
    }
}
