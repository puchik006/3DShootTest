using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class SimpleCharacterController : MonoBehaviour
{
    [Header("Movement settings")]
    [SerializeField, Range(1f, 10f)] private float _baseMovementSpeed = 5f;
    [SerializeField, Range(1f, 10f)] private float _rotationSpeed = 3f;
    [SerializeField, Range(1f, 3f)] private float _runSpeed = 2f;
    [SerializeField, Range(0.1f, 1f)] private float _jumpForce = 0.1f;
    private float _runSpeedMultiplier;
    private Rigidbody _rb;

    private void OnValidate() => _rb = GetComponent<Rigidbody>();


    public void Move(float horizontalInput, float verticalInput)
    {
        float currentMovementSpeed = _baseMovementSpeed * _runSpeedMultiplier;
        Vector3 movement = CalculateMovementVector(horizontalInput, verticalInput);
        Vector3 movementAmount = movement * currentMovementSpeed * Time.deltaTime;
        _rb.MovePosition(_rb.position + movementAmount);
    }

    public void Rotate(float mouseX)
    {
        Vector3 rotationAmount = Vector3.up * mouseX;
        _rb.MoveRotation(_rb.rotation * Quaternion.Euler(rotationAmount));
    }

    public void Run(bool isRun)
    {
        float walkMultiplier = 1f;
        _runSpeedMultiplier = isRun ? _runSpeed : walkMultiplier;
    }

    private Vector3 CalculateMovementVector(float horizontalInput, float verticalInput)
    {
        Vector3 forward = _rb.transform.forward;
        Vector3 right = _rb.transform.right;
        Vector3 movement = (forward * verticalInput) + (right * horizontalInput);

        return movement.normalized;
    }
}
