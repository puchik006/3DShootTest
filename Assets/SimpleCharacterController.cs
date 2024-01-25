using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class SimpleCharacterController : MonoBehaviour
{
    [Header("Movement settings")]
    [SerializeField, Range(1f, 10f)] private float _movementSpeed = 5f;
    [SerializeField, Range(1f, 10f)] private float _rotationSpeed = 3f;
    private Rigidbody _rb;

    private void OnValidate() => _rb = GetComponent<Rigidbody>();

    public void MoveCharacter(float horizontalInput,float verticalInput)
    {
        Vector3 movement = CalculateMovementVector(horizontalInput, verticalInput);
        Vector3 movementAmount = movement * _movementSpeed * Time.deltaTime;
        _rb.MovePosition(_rb.position + movementAmount);
    }

    public void RotateCharacter(float mouseX)
    {
        Vector3 rotationAmount = new (0f, mouseX * _rotationSpeed, 0f);
        _rb.MoveRotation(_rb.rotation * Quaternion.Euler(rotationAmount));
    }

    private Vector3 CalculateMovementVector(float horizontalInput, float verticalInput)
    {
        // Get the forward and right vectors based on the character's rotation
        Vector3 forward = _rb.transform.forward;
        Vector3 right = _rb.transform.right;

        // Remove the y-component to ensure movement stays on the horizontal plane
        forward.y = 0f;
        right.y = 0f;

        // Normalize the vectors to ensure consistent movement speed in all directions
        forward.Normalize();
        right.Normalize();

        // Calculate the movement vector based on input and character rotation
        Vector3 movement = (forward * verticalInput) + (right * horizontalInput);

        return movement.normalized;
    }
}

