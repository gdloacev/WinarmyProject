using UnityEngine;
public class GameSceneManager : Singleton<GameSceneManager>
{
    public GameState gameState;
    // Start is called before the first frame update
    void Start()
    {
        gameState = GameState.Intro;
    }

    void Update()
    {
        switch (gameState)
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
                    gameState = GameState.Playing;
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

    private static bool IsCameraTransitionDone()
    {
        return CameraManager.Instance.IsTransitionDone();
    }

    private void StartTransition()
    {
        CameraManager.Instance.TransitionToMain();
        gameState = GameState.Transition;
    }
}
