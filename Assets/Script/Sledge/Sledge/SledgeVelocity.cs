using UnityEngine;

public class SledgeVelocity : MonoBehaviour
{
    [SerializeField]
    private float _maxSpeed;

    [SerializeField]
    private float _propulsionSpeed;

    [SerializeField]
    private float _directionnalBaseSpeed;

    [SerializeField]
    private float _slopeFactor;

    private float _direction;

    private Rigidbody _rb;
    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
        //_rb.FreezeRotation = true;
    }

    private void FixedUpdate()
    {
       // Debug.Log("Velocity: " + _rb.linearVelocity.magnitude);

        Vector3 force = transform.up * _propulsionSpeed;
        _rb.AddForce(force, ForceMode.Acceleration);
        if (_direction != 0)
        {
            force = transform.forward * _directionnalBaseSpeed * _direction;
            _rb.AddForce(force, ForceMode.Acceleration);
        }
        
        if (Physics.Raycast(transform.position, Vector3.down, out RaycastHit hit, 1f))
        {
            Vector3 slopeDirection = Vector3.ProjectOnPlane(Vector3.down, hit.normal);
            _rb.AddForce(slopeDirection * _slopeFactor, ForceMode.Acceleration);
        }

        if (_rb.linearVelocity.magnitude > _maxSpeed)
        {
            _rb.linearVelocity = _rb.linearVelocity.normalized * _maxSpeed;
        }
    }

    public void MoveDirection(float direction)
    {
        /*Vector3 force = transform.forward * _directionnalBaseSpeed * direction;
        _rb.AddForce(force, ForceMode.Acceleration);*/
        _direction = direction;
    }
}
