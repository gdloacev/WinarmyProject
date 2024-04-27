﻿using UnityEngine;

public class UIManager : Singleton<UIManager>
{
    public GameObject gameplayUI;
    public GameObject introUI;
    public GameObject winPanel;
    public GameObject losePanel;
        
    void Update()
    {
        switch (GameSceneManager.Instance.GameState)
        {
            case GameState.Intro:
                gameplayUI.SetActive(false);
                introUI.SetActive(true);
                break;

            case GameState.Transition:
                gameplayUI.SetActive(false);
                introUI.SetActive(false);
                break;

            case GameState.Playing:
                gameplayUI.SetActive(true);
                introUI.SetActive(false);
                break;

            case GameState.Paused:
                gameplayUI.SetActive(false);
                introUI.SetActive(false);
                break;

            case GameState.Restart:
                gameplayUI.SetActive(true);
                losePanel.SetActive(false);
                winPanel.SetActive(false);
                break;
        }
    }
}