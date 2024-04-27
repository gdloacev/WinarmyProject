using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _speed = 5f;
    [SerializeField] private float _jumpSpeed = 5f;
    [SerializeField] private float _checkDistance = 1.0f;
    [SerializeField] private Vector3 _rayOffset = Vector3.down;
    [SerializeField] private bool _allowMovement = true;
    public Animator animator;

    private Rigidbody _rb = null;
    private int _groundLayerMask = 0;
    private float horizontal = 0f;
    private float vertical = 0f;

    private void Awake() { 
        _rb = GetComponent<Rigidbody>();
        _groundLayerMask = LayerMask.GetMask("Ground");
    }
    private void Update()
    {
        if (GameSceneManager.Instance.GameState != GameState.Playing) return;
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
    }

    private void FixedUpdate()
    {
        if (_allowMovement)
        {
            Move(horizontal, vertical);
            if (Input.GetButtonDown("Fire1") && IsGrounded()) transform.position += _jumpSpeed * Time.fixedDeltaTime * Vector3.up;
        }
        else
        {
            animator.SetFloat("Speed", 0f);
        }
    }

    public void Move(float horizontal, float vertical)
    {
        if (Mathf.Abs(horizontal) < 0.001f && Mathf.Abs(vertical) < 0.001f)
        {
            animator.SetFloat("Speed", 0f);
            return;
        }
        else
        {
            animator.SetFloat("Speed", 1f);
        }

        // Creating a Vector3 based on input and speed
        Vector3 movement = new Vector3(horizontal, 0.0f, vertical) * (_speed * Time.deltaTime);

        // Apply movement to the Rigidbody
        _rb.velocity = movement;
    }

    private bool IsGrounded()
    {
        bool isGrounded = Physics.Raycast(transform.position + _rayOffset, Vector3.down, out RaycastHit hit, _checkDistance, _groundLayerMask);
        return isGrounded;
    }
    public void SetAllowMovement(bool value) =>  _allowMovement = value;
    public bool IsMovementAllowed() => _allowMovement;
}
