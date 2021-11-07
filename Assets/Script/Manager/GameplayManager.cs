using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameplayManager : MonoBehaviour
{
    public static GameplayManager Instance;

    public TextMeshProUGUI life;
    public int scoreValue = 0;
    public TextMeshProUGUI score;
    public GameObject panelGameOver;
    public GameObject infoPanel;
    public int level = 1;
    
    private void Awake() {
        Instance = this;
        score.text = "Score : "+scoreValue.ToString();
        panelGameOver.SetActive(false);
        infoPanel.SetActive(false);
    }

    private void Update()
    {
        if (scoreValue <= 0)
        {
            scoreValue = 0;
        }else if (scoreValue >= 3000 && level == 1)
        {
            infoPanel.SetActive(true);
            level = 2;
            Invoke("loadNextLevel", 10);
        }
        score.text = "Score : "+scoreValue.ToString();
    }

    public void loadNextLevel()
    {
        level = 2;
        SceneManager.LoadScene(2);
    }

    public void finish()
    {
        level = 1;
        newScore();
        infoPanel.SetActive(true);
        Invoke("menuButton",5f);
    }

    public void retryButton()
    {
        SceneManager.LoadScene(level);
    }
    
    public void menuButton()
    {
        SceneManager.LoadScene(0);
    }
    public bool newScore()
    {
        if (PlayerPrefs.GetInt("highScore",0) < scoreValue)
        {
            PlayerPrefs.SetInt("highScore",scoreValue);
            return true;
        }

        return false;
    }
}
