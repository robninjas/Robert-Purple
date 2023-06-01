using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tetromino : MonoBehaviour
{
    private float previousTime;
    public float fallTime = .8f;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.LeftArrow))
        {
            transform.position += Vector3.left;
        }

        if (Input.GetKeyUp(KeyCode.RightArrow))
        {
            transform.position += Vector3.right;
        }

        float tempTime = fallTime;

        if (Input.GetKey(KeyCode.DownArrow)) { tempTime = tempTime*.1f;  }

        if (Time.time - previousTime > tempTime)
        {
            transform.position += Vector3.down;
            previousTime = Time.time;
        }
    }
}
