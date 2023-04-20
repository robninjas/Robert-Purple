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

    private void Awake()
    {
        
    }

    protected override void ChildUpdate()
    {

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        node node_ = collision.GetComponent<node>();

        if (node_ != null)
        {
            int index = Random.Range(0, node_.availableDirections.Count);

            if (node_.availableDirections[index] == -direction)
            {
                index += 1;

                if (index == node_.availableDirections.Count)
                {
                    index = 0;
                }
            }

            SetDirection(node_.availableDirections[index]);
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
