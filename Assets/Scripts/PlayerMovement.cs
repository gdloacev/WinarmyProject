using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _speed = 5f;
    [SerializeField] private float _jumpSpeed = 5f;
    [SerializeField] private float _checkDistance = 1.0f;
    [SerializeField] private Vector3 _rayOffset = Vector3.down;

    private Rigidbody _rb = null;
    private int _groundLayerMask = 0;  

    private void Awake() { 
        _rb = GetComponent<Rigidbody>();
        _groundLayerMask = LayerMask.GetMask("Ground");
    }
    private void Update()
    {  
        var horizontal = Input.GetAxis("Horizontal");
        var vertical = Input.GetAxis("Vertical");
        if (horizontal > 0.0001f) transform.position += _speed * Time.deltaTime * Vector3.right;
        if (horizontal < -0.0001f) transform.position += _speed * Time.deltaTime * Vector3.left;
        if (vertical > 0.0001f) transform.position += _speed * Time.deltaTime * Vector3.forward;
        if (vertical < -0.0001f) transform.position += _speed * Time.deltaTime * Vector3.back;
        if (Input.GetButtonDown("Fire1") && !IsGrounded()) transform.position += _jumpSpeed * Time.deltaTime * Vector3.up;
    }

    private bool IsGrounded()
    {
        bool isGrounded = Physics.Raycast(transform.position + _rayOffset, Vector3.down, out RaycastHit hit, _checkDistance, _groundLayerMask);
        return isGrounded;
    }
}
