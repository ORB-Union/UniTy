using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour {

    public GameObject pauseButton, pausePanel;

    public void Start()
    {
        pausePanel.SetActive(false);
        pauseButton.SetActive(true);
    }


    public void OnPause()
    {
        pausePanel.SetActive(true);
        pauseButton.SetActive(false);
        Time.timeScale = 0;

    }


    public void UnPause()
    {
        pausePanel.SetActive(false);
        pauseButton.SetActive(true);
        Time.timeScale = 1;
    }

    public void TitleButton()
    {
        Invoke("MainTitleGame", 0f);
    }

    void MainTitleGame()
    {
        Application.LoadLevel("MainTitle");

    }


}
