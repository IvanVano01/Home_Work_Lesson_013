using UnityEngine;

public class Mover : MonoBehaviour
{

    [Header("Links")]
    [SerializeField] private LayerMask _groundMask;
    [SerializeField] private Transform _groundChekerPosition;
    [SerializeField] private InputHandler _inputHandler;

    [Header("Configs")]
    [SerializeField] private float _rotationForce;
    [SerializeField] private float _jumpForce;
    [SerializeField] float _maxVelocity;

    private Rigidbody _rigidbody;

    private float _deadZone = 0.05f;
    private float _radiusCheckSphere = 0.6f;

    private bool _isGrounded;
    private bool _isMoving;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        CheckGruond();
    }

    private void FixedUpdate()
    {
        if (_isMoving == false)
            return;

        Move();
        Jump();
        MovingSpeedLimit();
    }

    public void SetMovingTrue() => _isMoving = true;
    public void SetMovingFalse() => _isMoving = false;

    public void SetSleeping()
    {
        _rigidbody.isKinematic = true;
    }

    public void SetWakeUp()
    {
        _rigidbody.isKinematic = false;
    }

    public void MoveStartPosition(Vector3 position)
    {
        _rigidbody.MovePosition(position);
    }

    private void Move()
    {
        Vector3 directionForce = new Vector3(_inputHandler.InputHorizontal, 0, _inputHandler.InputVertical);

        if (Mathf.Abs(_inputHandler.InputHorizontal) > _deadZone || Mathf.Abs(_inputHandler.InputVertical) > _deadZone)
            _rigidbody.AddForce(directionForce * _rotationForce, ForceMode.Acceleration);
    }

    private void Jump()
    {
        if (_inputHandler.IsPressJump && _isGrounded)
            _rigidbody.AddForce(Vector3.up * _jumpForce, ForceMode.Impulse);
    }

    private void MovingSpeedLimit()
    {
        if (_rigidbody.velocity.magnitude >= _maxVelocity)
            _rigidbody.velocity = _rigidbody.velocity.normalized * _maxVelocity;
    }

    private void CheckGruond()
    {
        _isGrounded = Physics.CheckSphere(_groundChekerPosition.transform.position, _radiusCheckSphere, _groundMask);
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawSphere(_groundChekerPosition.transform.position, _radiusCheckSphere);
    }
}
