using UnityEngine;

public class ThirdPersonCamera : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private Vector3 _offset = new Vector3(0f, 2f, -5f);
    [SerializeField, Range(1f, 10f)] private float _horizontalRotationSpeed = 5f;
    [SerializeField, Range(1f, 10f)] private float _verticalRotationSpeed = 2f;
    private float _verticalRotation = 0f;

    private void Awake()
    {
        if (_target == null)
        {
            Debug.LogError("Please assign a target (character's transform) to the camera script.");
            return;
        }
    }

    public void MoveCamera(float mouseY)
    {
        // Calculate the desired rotation based on the target's current rotation
        float targetRotationAngle = _target.eulerAngles.y;
        Quaternion targetRotation = Quaternion.Euler(0f, _target.eulerAngles.y, 0f);

        // Read mouse input for vertical camera movement
        _verticalRotation -= mouseY * _verticalRotationSpeed;
        _verticalRotation = Mathf.Clamp(_verticalRotation, -40f, 40f);

        // Calculate the new rotation based on both horizontal and vertical rotation
        Quaternion verticalRotation = Quaternion.Euler(_verticalRotation, 0f, 0f);

        // Smoothly interpolate the camera's position and rotation towards the desired values
        transform.position = Vector3.Lerp(transform.position, _target.position + targetRotation * verticalRotation * _offset, Time.deltaTime * _horizontalRotationSpeed);
        transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation * verticalRotation, Time.deltaTime * _horizontalRotationSpeed);
    }
}
