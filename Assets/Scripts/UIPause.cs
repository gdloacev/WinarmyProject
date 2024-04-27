using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using TMPro;
using UnityEngine.UI;

public class UIPause : MonoBehaviour
{
    private bool isPaused = false;
    [SerializeField] GameObject menuPause;
    // public TMP_Button buttonToSelect;
    public Button buttonToSelect;

    // Update is called once per frame
    void Update()
    {
        if (GameSceneManager.Instance.GameState != GameState.Playing) return;

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            EventPause();
        }
    }

    public void EventPause()
    {

        isPaused = !isPaused;

        menuPause.SetActive(isPaused);

        if (isPaused)
        {
            Time.timeScale = 0f;
            EventSystem.current.SetSelectedGameObject(buttonToSelect.gameObject);
        }
        else
        {
            Time.timeScale = 1f;
            EventSystem.current.SetSelectedGameObject(null);
        }
    }

    public void GoToStartingScreen()
    {
        SceneManager.LoadScene("GamePlayScene");
    }
}
