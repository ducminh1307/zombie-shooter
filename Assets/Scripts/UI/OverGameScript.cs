using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OverGameScript : MonoBehaviour
{
    [SerializeField] private GameObject winPanel;
    [SerializeField] private GameObject losePanel;

    private void Awake()
    {
        GameManager.onPlayerWin += WinGame;
        Player.onPlayerDeath += LoseGame;
    }

    private void OnDestroy()
    {
        GameManager.onPlayerWin -= WinGame;
        Player.onPlayerDeath -= LoseGame;
    }

    private void WinGame()
    {
        Time.timeScale = 0;
        winPanel.SetActive(true);
    }

    private void LoseGame()
    {
        Time.timeScale = 0;
        losePanel.SetActive(true);
    }

    public void OnClickRestart()
    {
        SceneLoaderManager.instance.LoadScene(1);
    }

    public void OnClickMenu()
    {
        SceneLoaderManager.instance.LoadScene(0);
    }
}
