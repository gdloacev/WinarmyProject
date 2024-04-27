using System;
using UnityEngine;
public class GameSceneManager : Singleton<GameSceneManager>
{
    [NonSerialized]
    public GameState GameState;

    public GameObject lavaHazard;
    // Start is called before the first frame update
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
                if (Input.GetKeyDown(KeyCode.Space)) // Assuming space starts the game
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
}
