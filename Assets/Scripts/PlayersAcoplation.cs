using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayersAcoplation : MonoBehaviour
{
    [SerializeField] private Transform _acoplationPoint = null;

    private PlayerMovement _playerMovement = null;
    private Rigidbody _rb;
    

    private void Awake() { 
        _playerMovement = GetComponent<PlayerMovement>();
        _rb = GetComponent<Rigidbody>();        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision != null && collision.gameObject.CompareTag("Dino") && _playerMovement.IsMovementAllowed()) { 
            transform.position = _acoplationPoint.position;
            transform.parent = _acoplationPoint.parent;
            _playerMovement.SetAllowMovement(false);
            collision.gameObject.GetComponent<PlayerMovement>().SetAllowMovement(true);
        }
    }
}
