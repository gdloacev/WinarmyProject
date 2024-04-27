using UnityEngine;

public class MenuStart : MonoBehaviour
{
    [SerializeField] SoundManager _soundManager = null;

    private void Start() => _soundManager.PlayMusic(0, true);

    public void GoToTutorial()
    {
        GameSceneManager.Instance.StartGame();
    }

    public void ExitGame()
    {
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #else
            Application.Quit();
        #endif
    }
}
