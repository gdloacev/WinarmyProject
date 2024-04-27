using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSceneManager : Singleton<GameSceneManager>
{
    [SerializeField] private SoundManager _soundManager = null;

    [NonSerialized]
    public GameState GameState;

    private bool activateStart = false;

    public GameObject lavaHazard;

    void Start()
    {
        GameState = GameState.Intro;
        lavaHazard.SetActive(false);
    }

    void Update()
    {
        switch (GameState)
        {
            case GameState.Intro:
                if (activateStart)
                {
                    StartTransition();
                }
                break;

            case GameState.Transition:
                // Move camera to gameplay position
                if (IsCameraTransitionDone())
                {
                    lavaHazard.SetActive(true);
                    GameState = GameState.Playing;
                }
                break;

            case GameState.Playing:
                // Normal gameplay logic
                break;

            case GameState.Paused:
                // Game is paused, nothing moves
                break;

            case GameState.Restart:
                StartTransition();
                break;

        }
    }

    private bool IsCameraTransitionDone()
    {
        return CameraManager.Instance.IsTransitionDone();
    }

    private void StartTransition()
    {
        GameState = GameState.Transition;
        CameraManager.Instance.TransitionToMain();
    }

    public void StartGame()
    {
        _soundManager.PlayMusic(1, true);
        activateStart = true;
    }

    public void RestartGame()
    {
        GameState = GameState.Restart;
    }
}
