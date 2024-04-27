using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using TMPro;
using UnityEngine.UI;

public class UIPause : MonoBehaviour
{

    [SerializeField] GameObject menuPause = null;
    [SerializeField] AudioClip  _audioPause = null;
    [SerializeField] AudioClip _audioNotPause = null;

    public Button buttonToSelect;

    private AudioSource _audioSource = null;
    private bool isPaused = false;

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (GameSceneManager.Instance.GameState != GameState.Playing) return;
        if (Input.GetKeyDown(KeyCode.Escape)) EventPause();
    }

    public void EventPause()
    {

        isPaused = !isPaused;

        menuPause.SetActive(isPaused);

        if (isPaused)
        {
            Time.timeScale = 0f;
            EventSystem.current.SetSelectedGameObject(buttonToSelect.gameObject);
            _audioSource.PlayOneShot(_audioPause);
        }
        else
        {
            Time.timeScale = 1f;
            EventSystem.current.SetSelectedGameObject(null);
            _audioSource.PlayOneShot(_audioNotPause);
        }
    }

    public void GoToStartingScreen()
    {
        SceneManager.LoadScene("GamePlayScene");
    }
}
