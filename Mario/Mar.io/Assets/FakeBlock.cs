using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FakeBlock : MonoBehaviour
{
    public GameObject item;
    public int maxHits = -1;
    public Sprite emptyBlock;
    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponentInChildren<Animator>();
    }

    public void Hit()
    {
        if (maxHits <= 0)
        {
            return;
        }

        if (item != null)
        {
            //Instantiate(item, transform.position + Vector3.up, Quaternion.identity);
            Instantiate(item, transform);


            animator.SetTrigger("Hit");
            maxHits--;
        }

        if (maxHits == 0)
        {
            SpriteRenderer spriteRenderer = GetComponentInChildren<SpriteRenderer>();
            spriteRenderer.sprite = emptyBlock;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
