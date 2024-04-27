using DefaultNamespace;
using UnityEngine;

public class PlayersAcoplation : MonoBehaviour
{
    [SerializeField] private SoundManager _soundManager = null;

    private Transform _acoplationPoint = null;
    private PlayerMovement _playerMovement;
    private Size _size;

    private void Awake()
    {
        _playerMovement = GetComponent<PlayerMovement>();
        _size = GetComponent<Size>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        var size = collision.gameObject.GetComponent<Size>();
        if (collision != null && collision.gameObject.CompareTag("Dino") && _playerMovement.IsMovementAllowed() && (this.CompareTag("Mouse") || this.CompareTag("Dino")) && (size.size - _size.size) == 1 ) {
            var source = this.CompareTag("Mouse") ? this.gameObject : this.gameObject.transform.GetChild(2).gameObject;
            var hasParent = this.CompareTag("Dino");
            var soundIndex = (size.size < 4) ? 3 : 0;
            _soundManager.PlayOneShot(soundIndex);
            PlayerAcoplation(source, collision.gameObject, hasParent);
        }
    }

    private void PlayerAcoplation(GameObject source, GameObject target, bool hasParent) {
        _acoplationPoint = target.transform.GetChild(1);
        var parent = (hasParent) ? source.transform.parent : null;
        if (parent != null)
        {
            parent.GetComponent<PlayerMovement>().SetAllowMovement(false);
            parent.GetComponent<Rigidbody>().velocity = Vector3.zero;
            parent.tag = "Untagged";
        }
        source.transform.position = _acoplationPoint.position;
        source.transform.SetParent(_acoplationPoint.parent);
        source.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
        source.GetComponent<PlayerMovement>().SetAllowMovement(false);
        target.GetComponent<PlayerMovement>().SetAllowMovement(true);        
    }
}
