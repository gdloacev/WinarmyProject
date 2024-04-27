using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Lose : MonoBehaviour
{
    [SerializeField] private GameObject canvasLose;
    [SerializeField] private SoundManager _soundManager = null;

    private void OnTriggerEnter(Collider other)
    {
        // On Lose
        if (other.gameObject.CompareTag("Mouse"))
        {
            Debug.Log("You've Died!");
            GameSceneManager.Instance.GameState = GameState.GameOver;

            /*activate death animation*/

            // Load LoseScreen after waiting time for animation to play out
            StartCoroutine(LoadCorutine());
        }
    }

    IEnumerator LoadCorutine()
    {
        _soundManager.PlayOneShot(1);
        yield return new WaitForSeconds(0.5f);
        _soundManager.PlayMusic(3);
        canvasLose.SetActive(true);
    }
}
