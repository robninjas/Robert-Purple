using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pwnerpellet : pellet
{
    protected override void Eat()
    {
        base.Eat();

        GameObject[] ghosts = GameObject.FindGameObjectsWithTag("ghost");

        foreach (GameObject ghost in ghosts)
        {
            ghost.GetComponent<ghost>().Frighten();
        }
    }
}
