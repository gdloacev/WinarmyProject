using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Win : MonoBehaviour
{
    [SerializeField] private GameObject lavaHazzard;
    [SerializeField] private GameObject canvasWin;
    [SerializeField] private SoundManager _soundManager = null;

    private void OnCollisionEnter(Collision other)
    {
        // On Win
        if (other.gameObject.CompareTag("Dino"))
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
        _soundManager.PlayMusic(2);
        canvasWin.SetActive(true);
    }
}
