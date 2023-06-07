using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tetromino : MonoBehaviour
{
    private float previousTime;
    public float fallTime = .8f;

    public static int width = 10;
    public static int height = 20;

    public Vector3 rotationPoint;

    public static Transform[,] grid = new Transform[width, height];

    public void checklines()
    {
        for (int i = height - 1; 1 >= 0; i--) {
            if (hasline(i))
            {
                deleteline(i);
                rowdown(i);
            }
        }
    }

    public bool hasline(int i)
    {
        for (int j=0; j < width; j++)
        {
            try
            {
                if (grid[j, i] == null)
                {
                    return false;
                }

                return true;
            }

            catch
            {
                return false;
            }
        }

        return false;
    }

    public void deleteline(int i)
    {
        for (int j = 0; j < width; j++)
        {
            try
            {
            Destroy(grid[j, i].gameObject);
            grid[j, i] = null;
            }

            catch { }
        }
    }

    public void rowdown(int i)
    {
        for (int y = i; y < height; y++)
        {
            for (int x = 0; x < width; x++)
            {
                    if (grid[x, y] != null)
                    {
                        grid[x, y - 1] = grid[x, y];
                        grid[x, y] = null;
                        grid[x, y - 1].transform.position += Vector3.down;
                    }
            }
        }
    }

    // Update is called once per frame

    public void AddToGrid ()
    {
        foreach (Transform child in transform)
        {
            int x = Mathf.RoundToInt(child.transform.position.x);
            int y = Mathf.RoundToInt(child.transform.position.y);

            grid[x, y] = child;
        }
    }

    public bool ValidMove()
    {
        foreach (Transform child in transform)
        {
            int x = Mathf.RoundToInt(child.transform.position.x);
            int y = Mathf.RoundToInt(child.transform.position.y);

            int x_access = 0;
            int y_access = 0;

            //y = Mathf.Clamp(y, 5, 9999);

            if (x > 0)
            {
                x_access = x - 1;
            }


            //if (y > 0)
            //{
            //    y_access = y;
            //}


            //if (y > 0 && grid[x_access, y] != null)
            //{
            //    return false;
            //}

            try
            {
                if (grid[x, y] != null)
                {
                    //print("X: " + x.ToString());
                    //print("Y: " + y.ToString());


                    return false;
                }
            }

            catch (Exception e)
            {
                //print("X: " + x.ToString());
                //print("Y: " + y.ToString());

                //print(e.ToString());
            }



            if (x < 0 || y < 0 || x >= width || y >= height)
            {
                return false;
            }
        }

        return true;
    }

    void Update()
    {
        if (Input.GetKeyUp(KeyCode.UpArrow))
        {
            Vector3 convertedPoint = transform.TransformPoint(rotationPoint);
            transform.RotateAround(convertedPoint, Vector3.forward, 90);

            if (!ValidMove()) { transform.RotateAround(convertedPoint, Vector3.forward, -90); }
        }

        if (Input.GetKeyUp(KeyCode.LeftArrow))
        {
            transform.position += Vector3.left;

            if (!ValidMove()) { transform.position -= Vector3.left; }
        }

        if (Input.GetKeyUp(KeyCode.RightArrow))
        {
            transform.position += Vector3.right;

            if (!ValidMove()) { transform.position -= Vector3.right; }
        }

        float tempTime = fallTime;

        if (Input.GetKey(KeyCode.DownArrow)) { 
      
                tempTime = tempTime * .1f;
      
        }

        if (Time.time - previousTime > tempTime)
        {
            transform.position += Vector3.down;

            if (!ValidMove()) { 
                transform.position -= Vector3.down;
                this.enabled = false; 
                AddToGrid();
                checklines();
                FindObjectOfType<Spwner>().spwntetromino(); }

            previousTime = Time.time;
        }
    }
}
