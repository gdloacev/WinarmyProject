using DefaultNamespace;
using System.Collections;
using UnityEngine;

public class Win : MonoBehaviour
{
    [SerializeField] private GameObject lavaHazzard;
    [SerializeField] private GameObject canvasWin;
    [SerializeField] private SoundManager _soundManager = null;

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.name == "Pista") return;

        // On Win
        if (this.CompareTag("Dino") && this.GetComponent<Size>().size == 4)
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