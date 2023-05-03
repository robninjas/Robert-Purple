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
        body.SetActive(true);
        eyes.SetActive(true);
        blue.SetActive(false);
        white.SetActive(false);
        frightened = false;
        Invoke("LeaveHome", homeDuration);
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
        if (atHome && collision.gameObject.layer == LayerMask.NameToLayer("Obstacle"))
        {
            SetDirection(-direction);
        }

        if (collision.gameObject.CompareTag("pacman"))
        {
            if (frightened)
            {
                transform.position = new Vector3(0, -.2f, -1);
                body.SetActive(false);
                eyes.SetActive(true);
                blue.SetActive(false);
                white.SetActive(false);
                atHome = true;
                CancelInvoke();
                Invoke("LeaveHome", 4f);
            }

            else
            {
                Destroy(collision.gameObject);
                Debug.Log("Et tu brute? (you died)");
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.Log(collision.gameObject.name);

        node _node = collision.GetComponent<node>();

        if (_node != null)
        {
            int index = Random.Range(0, _node.availableDirections.Count);

            if (_node.availableDirections[index] == -direction)
            {
                index += 1;
            }

            if (index == _node.availableDirections.Count)
            {
                index = 0;
            }

            SetDirection(_node.availableDirections[index]);
        }
    }

    private void LeaveHome()
    {
        transform.position = new Vector3(0, 3.5f, -1f);
        direction = new Vector2(-1, 0);
        atHome = false;
        frightened = false;
        body.SetActive(true);
        eyes.SetActive(true);
        blue.SetActive(false);
        white.SetActive(false);
    }

    public void Frighten()
    {
        if (!atHome)
        {
            frightened = true;
            body.SetActive(false);
            eyes.SetActive(false);
            blue.SetActive(true);
            white.SetActive(false);
            Invoke("Flash", 1f);
        }
    }

    private void Flash()
    {
        body.SetActive(false);
        eyes.SetActive(false);
        blue.SetActive(false);
        white.SetActive(true);
        Invoke("Reset", 4f);
    }

    private void Reset()
    {
        frightened = false;
        body.SetActive(true);
        eyes.SetActive(true);
        blue.SetActive(false);
        white.SetActive(false);
    }
}
