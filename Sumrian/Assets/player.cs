using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class player : MonoBehaviour
{
    public string playerName;
    private ulong highestPop;
    private GameplayManager gameManager;

    public TMP_Text nametext;
    public TMP_Text yeartext;
    public TMP_Text highestpoptext;


    // Start is called before the first frame update
    void Start()
    {
        nametext.text = "Ruler: " + playerName;

        gameManager = GetComponent<GameplayManager>();
    }

    // Update is called once per frame
    void Update()
    {
        yeartext.text = "Year: " + gameManager.year;

        if (gameManager.population > highestPop)
        {
            highestPop = gameManager.population;
            highestpoptext.text = "Highest Population: " + highestPop;
        }
    }
}
