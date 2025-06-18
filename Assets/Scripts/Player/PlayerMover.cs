using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMover : MonoBehaviour
{
    [SerializeField] private float moveForce = 10f;

    public float MoveSpeed => moveForce; // Bu satır eklendi

    private Rigidbody rb;
    private Vector3 moveDirection;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        float moveX = Input.GetAxisRaw("Horizontal"); // A (-1) → D (+1)
        float moveZ = Input.GetAxisRaw("Vertical");   // S (-1) → W (+1)

        moveDirection = new Vector3(moveX, 0f, moveZ).normalized;
    }

    private void FixedUpdate()
    {
        rb.AddForce(moveDirection * moveForce, ForceMode.Force);
    }
}
