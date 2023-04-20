using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pellet : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    { 
        if (collision.gameObject.CompareTag("pacman"))
        {
            Eat();
        }
    }

    protected virtual void Eat()
    {
        gameObject.SetActive(false);
    }
}
