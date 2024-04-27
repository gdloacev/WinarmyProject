using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackHazardMovement : MonoBehaviour
{
    [SerializeField] private float speed;

    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }
}
