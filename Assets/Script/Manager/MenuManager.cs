using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public GameObject level1Panel;
    public GameObject mainPanel;
    private void Start()
    {
        mainPanel.SetActive(true);
        level1Panel.SetActive(false);
    }

    public void PlayGame()
    {
        mainPanel.SetActive(false);
        level1Panel.SetActive(true);
        
        Invoke("LoadLevel1",10);
    }

    public void LoadLevel1()
    {
        SceneManager.LoadScene(1);
    }

    public void quitButton()
    {
        Application.Quit();
    }
}
