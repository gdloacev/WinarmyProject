using System.Collections;
using Cinemachine;
using UnityEngine;

public class CameraManager : Singleton<CameraManager>
{
    public CinemachineBrain brain;
    public CinemachineVirtualCamera introCamera;
    public CinemachineVirtualCamera mainCamera;

    private void Start()
    {
        mainCamera.Priority = 0;
        introCamera.Priority = 10;
    }

    public void TransitionToMain()
    {
        StartCoroutine(TransitionDelayed());
    }

    private IEnumerator TransitionDelayed()
    {
        yield return new WaitForSeconds(1f);
        mainCamera.Priority = 10;
        introCamera.Priority = 0;
    }

    public bool IsTransitionDone()
    {
        return brain.ActiveVirtualCamera == mainCamera && !brain.IsBlending;
    }
}