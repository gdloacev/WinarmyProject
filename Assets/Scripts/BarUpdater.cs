using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class BarUpdater : MonoBehaviour
{
    public Slider slider;
    public Transform goal;
    public Transform player;
    public float _maxDistance;
    public float currentDistance;
    
    private void Start()
    {
        _maxDistance = Vector3.Distance(goal.position, player.position);
        currentDistance = _maxDistance;
        slider.value = 0;
    }

    void Update()
    {
        currentDistance = Vector3.Distance(goal.position, player.position);
        currentDistance = _maxDistance - currentDistance;
        var curVal = slider.value;
        var newVal = currentDistance/_maxDistance;
        if (newVal > curVal)
        {
            slider.value = newVal;
        }
    }
}
