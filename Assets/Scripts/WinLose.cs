using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinLose : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        // On Lose
        if (other.gameObject.CompareTag("Back_Hazard"))
        {
            Debug.Log("You've Died!");

            /*activate death animation*/

            // Load LoseScreen after waiting time for animation to play out
            StartCoroutine(LoadCorutine("LoseScreen"));
        }

        // On Win
        if (other.gameObject.CompareTag("Dino_Chicken"))
        {
            Debug.Log("You've Won!");

            /*activate win animation*/

            // Load WinScreen after waiting time for animation to play out
            StartCoroutine(LoadCorutine("WinScreen"));
        }
    }

    IEnumerator LoadCorutine(string screen)
    {
        yield return new WaitForSeconds(5);
        SceneManager.LoadScene(screen);
    }
}
