using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gamemanager : MonoBehaviour
{
    public GameObject invader;
    public float space = 1f;
    public float offset = -10;

    // Start is called before the first frame update
    void Start()
    {
        for (int x = 0; x < 10; x++)
        {
            Instantiate(invader, new Vector2(x * space + offset, 3), Quaternion.identity);
            Instantiate(invader, new Vector2(x * space + offset, 3.75f), Quaternion.identity);
            Instantiate(invader, new Vector2(x * space + offset, 4.5f), Quaternion.identity);
        }
    }
}
