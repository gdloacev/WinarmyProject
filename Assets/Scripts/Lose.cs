using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Lose : MonoBehaviour
{
    [SerializeField] private GameObject canvasLose;

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
        yield return new WaitForSeconds(0.5f);
        canvasLose.SetActive(true);
    }
}
