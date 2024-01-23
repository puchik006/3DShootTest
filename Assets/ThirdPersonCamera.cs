using UnityEngine;

public class ThirdPersonCamera : MonoBehaviour
{
    [SerializeField] private Transform _target; // The target to follow (your character's transform)
    [SerializeField, Range(1f, 10f)] private float _rotationSpeed = 5f;
    [SerializeField] private Vector3 _offset = new Vector3(0f, 2f, -5f); // The offset from the target

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

        // Smoothly interpolate the camera's position and rotation towards the desired values
        transform.position = Vector3.Lerp(transform.position, _target.position + targetRotation * _offset, Time.deltaTime * _rotationSpeed);
        transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, Time.deltaTime * _rotationSpeed);
    }
}
