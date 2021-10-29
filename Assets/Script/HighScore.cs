using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HighScore : MonoBehaviour
{
    public TextMeshProUGUI highScoreTxt;
    public String highScoreLabel = "High score : ";
    public void Awake()
    {
        highScoreTxt.text = highScoreLabel+PlayerPrefs.GetInt("highScore",0).ToString();
    }

    public void Update()
    {
        highScoreTxt.text = highScoreLabel+PlayerPrefs.GetInt("highScore",0).ToString();
    }

    public void resetHighScore()
    {
        PlayerPrefs.SetInt("highScore", 0);
    }
}
