using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spwner : MonoBehaviour
{
    public GameObject[] tetrominoes;

    private void Start()
    {
        spwntetromino();
    }

    public void spwntetromino()
    {
        int randNum = Random.Range(0, tetrominoes.Length-1);
        GameObject randomTetromino = tetrominoes[randNum];
        Instantiate(randomTetromino, transform.position, Quaternion.identity);
    }
}
