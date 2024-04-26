using UnityEngine;

public class Rotator : MonoBehaviour
{
    public Vector3 rotation;

    public float rotationSpeed;


    void Update()
    {
        transform.Rotate(rotation, rotationSpeed * Time.deltaTime);
    }
}
