using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _speed = 5f;
    [SerializeField] private float _jumpSpeed = 5f;
    [SerializeField] private float _checkDistance = 1.0f;
    [SerializeField] private Vector3 _rayOffset = Vector3.down;
    [SerializeField] private bool _allowMovement = true;

    private Rigidbody _rb = null;
    private int _groundLayerMask = 0;  

    private void Awake() { 
        _rb = GetComponent<Rigidbody>();
        _groundLayerMask = LayerMask.GetMask("Ground");
    }
    private void Update()
    {
        if (GameSceneManager.Instance.GameState != GameState.Playing)
        {
            return;
        }

        if (_allowMovement)
        {
            var horizontal = Input.GetAxis("Horizontal");
            var vertical = Input.GetAxis("Vertical");
            Move(horizontal, vertical);
            if (Input.GetButtonDown("Fire1") && !IsGrounded()) transform.position += _jumpSpeed * Time.deltaTime * Vector3.up;
        }
    }

    public void Move(float horizontal, float vertical)
    {
        // Creating a Vector3 based on input and speed
        Vector3 movement = new Vector3(horizontal, 0.0f, vertical) * (_speed * Time.deltaTime);

        // Apply movement to the Rigidbody
        _rb.velocity = movement;
        
        //
        // if (horizontal > 0.0001f) transform.position += _speed * Time.deltaTime * Vector3.right;
        // if (horizontal < -0.0001f) transform.position += _speed * Time.deltaTime * Vector3.left;
        // if (vertical > 0.0001f) transform.position += _speed * Time.deltaTime * Vector3.forward;
        // if (vertical < -0.0001f) transform.position += _speed * Time.deltaTime * Vector3.back;
    }

    private bool IsGrounded()
    {
        bool isGrounded = Physics.Raycast(transform.position + _rayOffset, Vector3.down, out RaycastHit hit, _checkDistance, _groundLayerMask);
        return isGrounded;
    }
    public void SetAllowMovement(bool value) =>  _allowMovement = value;
    public bool IsMovementAllowed() => _allowMovement;
}
