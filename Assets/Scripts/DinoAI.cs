using System;
using UnityEngine;

public class DinoAI : MonoBehaviour
{
    public PlayerMovement controller;
    public bool run;
    public float threshold;

    private void Update()
    {
        if (GameSceneManager.Instance.GameState == GameState.Intro || GameSceneManager.Instance.GameState == GameState.Paused)
        {
            return;
        }

        if (run)
        {
            controller.Move(0, 1);
        }
        else if(Vector3.Distance(transform.position, GameSceneManager.Instance.lavaHazard.transform.position) < threshold)
        {
            run = true;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, threshold);
    }
}