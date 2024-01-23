using UnityEngine;

public class SimpleCharacterController : MonoBehaviour
{
    [SerializeField, Range(0f, 10f)] private float _movementSpeed = 5f;
    [SerializeField, Range(1f, 10f)] private float _rotationSpeed = 3f; // New variable for rotation speed
    private Rigidbody _rb;

    private void OnValidate()
    {
        _rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        // Get movement input
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // Calculate movement vector based on character rotation
        Vector3 movement = CalculateMovementVector(horizontalInput, verticalInput);

        // Move the character
        MoveCharacter(movement);

        // Rotate the character based on mouse input
        RotateWithMouse();
    }

    private void MoveCharacter(Vector3 direction)
    {
        Vector3 movementAmount = direction * _movementSpeed * Time.deltaTime;
        _rb.MovePosition(_rb.position + movementAmount);
    }

    private void RotateWithMouse()
    {
        float mouseX = Input.GetAxis("Mouse X");

        // Calculate rotation amount based on mouse input
        Vector3 rotationAmount = new Vector3(0f, mouseX * _rotationSpeed, 0f);

        // Apply rotation to the Rigidbody
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
