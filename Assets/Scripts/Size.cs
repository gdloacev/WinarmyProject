using System;
using UnityEngine;

namespace DefaultNamespace
{
    public class Size : MonoBehaviour
    {
        public int size;

        private void OnCollisionEnter(Collision other)
        {
            Debug.Log($"{other.gameObject.name}");
        }
    }
}