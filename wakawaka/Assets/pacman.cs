using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pacman : movement
{
    protected override void ChildUpdate()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        if (horizontal != 0 || vertical != 0)
        {
            SetDirection(new Vector2(horizontal, vertical));
        }

        transform.right = direction;
    }
}
