using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Win : MonoBehaviour
{
    [SerializeField] private GameObject lavaHazzard;
    [SerializeField] private GameObject canvasWin;

    private void OnCollisionEnter(Collision other)
    {
        // On Win
        if (other.gameObject.CompareTag("Mouse"))
        {
            CameraManager.Instance.WinCamera();
            Debug.Log("You've Won!");
            lavaHazzard.SetActive(false);

            /*activate win animation*/

            // Load WinScreen after waiting time for animation to play out
            StartCoroutine(LoadCorutine());
        }
    }

    IEnumerator LoadCorutine()
    {
        yield return new WaitForSeconds(5);
        canvasWin.SetActive(true);
    }
}
