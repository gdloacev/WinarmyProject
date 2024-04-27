using System.Collections;
using Cinemachine;
using UnityEngine;

public class CameraManager : Singleton<CameraManager>
{
    public CinemachineBrain brain;
    public CinemachineVirtualCamera introCamera;
    public CinemachineVirtualCamera mainCamera;
    public CinemachineVirtualCamera winCamera;
    
    // private bool _transitionDone;
    public float delay;

    private void Start()
    {
        winCamera.Priority = 0;
        mainCamera.Priority = 0;
        introCamera.Priority = 10;
    }

    public void TransitionToMain()
    {
        StartCoroutine(TransitionDelayed());
    }

    private IEnumerator TransitionDelayed()
    {
        mainCamera.Priority = 10;
        introCamera.Priority = 0;
        yield return null;
        // yield return new WaitForSeconds(delay);
        // _transitionDone = true;
    }


    public bool IsTransitionDone()
    {
        // return _transitionDone;
        return brain.ActiveVirtualCamera == mainCamera && !brain.IsBlending;
    }

    public void WinCamera()
    {
        mainCamera.Priority = 0;
        introCamera.Priority = 0;
        winCamera.Priority = 10;
    }
}