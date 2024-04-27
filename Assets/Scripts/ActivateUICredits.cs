using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateUICredits : MonoBehaviour
{
    [SerializeField] private GameObject creditUI;
    [SerializeField] private GameObject startUI;
    [SerializeField] private GameObject loseUI;
    [SerializeField] private GameObject winUI;

    public void ActivateCredits()
    {
        creditUI.SetActive(true);
        startUI.SetActive(false);
        loseUI.SetActive(false);
        winUI.SetActive(false);
    }
}
