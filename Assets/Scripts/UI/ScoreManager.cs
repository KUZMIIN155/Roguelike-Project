using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public int score;
    public Text scoreDisplay;

    void Start()
    {

    }

    private void Update()
    {
        scoreDisplay.text = "Счет: " + score.ToString();
    }

    public void SKill()
    {
        score++;
    }

}
