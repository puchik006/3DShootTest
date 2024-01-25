using UnityEngine;

public class ThirdPersonCamera : MonoBehaviour
{
    [SerializeField] private Transform _target; // The target to follow (your character's transform)
    [SerializeField, Range(1f, 10f)] private float _rotationSpeed = 5f;
    [SerializeField] private Vector3 _offset = new Vector3(0f, 2f, -5f); // The offset from the target

    private float _verticalRotation = 0f;
    [SerializeField, Range(1f, 80f)] private float _verticalRotationSpeed = 2f;

    private void LateUpdate()
    {
        if (_target == null)
        {
            Debug.LogError("Please assign a target (character's transform) to the camera script.");
            return;
        }

        // Calculate the desired rotation based on the target's current rotation
        float targetRotationAngle = _target.eulerAngles.y;
        Quaternion targetRotation = Quaternion.Euler(0f, targetRotationAngle, 0f);

        // Read mouse input for vertical camera movement
        _verticalRotation -= Input.GetAxis("Mouse Y") * _verticalRotationSpeed;
        _verticalRotation = Mathf.Clamp(_verticalRotation, -40f, 40f);

        // Calculate the new rotation based on both horizontal and vertical rotation
        Quaternion verticalRotation = Quaternion.Euler(_verticalRotation, 0f, 0f);

        // Smoothly interpolate the camera's position and rotation towards the desired values
        transform.position = Vector3.Lerp(transform.position, _target.position + targetRotation * verticalRotation * _offset, Time.deltaTime * _rotationSpeed);
        transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation * verticalRotation, Time.deltaTime * _rotationSpeed);
    }
}
