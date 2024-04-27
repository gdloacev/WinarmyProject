using System.Collections;
using System.Collections.Generic;
using UnityEditor.ShaderKeywordFilter;
using UnityEngine;

public class PlayersAcoplation : MonoBehaviour
{
    private Transform _acoplationPoint = null;
    private PlayerMovement _playerMovement;

    private void Awake()
    {
       _playerMovement = GetComponent<PlayerMovement>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision != null && collision.gameObject.CompareTag("Dino") && _playerMovement.IsMovementAllowed() && (this.CompareTag("Mouse") || this.CompareTag("Dino"))) {
            var source = this.CompareTag("Mouse") ? this.gameObject : this.gameObject.transform.GetChild(3).gameObject;
            var hasParent = this.CompareTag("Dino");
            PlayerAcoplation(source, collision.gameObject, hasParent);
        }
    }

    private void PlayerAcoplation(GameObject source, GameObject target, bool hasParent) {
        _acoplationPoint = target.transform.GetChild(2);
        var parent = (hasParent) ? source.transform.parent : null;
        if (parent != null)
        {
            parent.GetComponent<PlayerMovement>().SetAllowMovement(false);
            parent.tag = "Untagged";
        }
        source.transform.position = _acoplationPoint.position;
        source.transform.SetParent(_acoplationPoint.parent);
        source.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
        source.GetComponent<PlayerMovement>().SetAllowMovement(false);
        target.GetComponent<PlayerMovement>().SetAllowMovement(true);        
    }
}
