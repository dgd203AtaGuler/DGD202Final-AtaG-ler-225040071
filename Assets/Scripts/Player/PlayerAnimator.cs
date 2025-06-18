using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    private Rigidbody _rigidbody;
    private PlayerMover _playerMover;
    [SerializeField] private Transform _mesh;

    private float _moveSpeed;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _playerMover = GetComponent<PlayerMover>();
    }

    private void Start()
    {
        _moveSpeed = _playerMover.MoveSpeed;
    }

    private void Update()
    {
        Vector3 velocity = _rigidbody.linearVelocity; // d�zeltildi
        float forwardVelocity = Vector3.Dot(velocity, transform.forward);
        if (forwardVelocity != 0)
            _mesh.localRotation *= Quaternion.Euler(Mathf.Deg2Rad * (360 / forwardVelocity), 0, 0);
    }
}
