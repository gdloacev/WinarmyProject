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
        if (collision != null && this.CompareTag("Mouse") && collision.gameObject.CompareTag("Dino") && _playerMovement.IsMovementAllowed()) {
            PlayerAcoplation(collision.gameObject);
        }
    }

    private void PlayerAcoplation(GameObject target) {
        transform.position = _acoplationPoint.position;
        transform.parent = _acoplationPoint.parent;
        _rb.constraints = RigidbodyConstraints.FreezeAll;
        _playerMovement.SetAllowMovement(false);
        target.GetComponent<PlayerMovement>().SetAllowMovement(true);
    }
}
