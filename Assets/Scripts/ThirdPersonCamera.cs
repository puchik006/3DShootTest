using UnityEngine;

[RequireComponent(typeof(Camera))]
public class ThirdPersonCamera : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private Vector3 _offset = new Vector3(0f, 2f, -5f);
    [SerializeField, Range(1f, 10f)] private float _horizontalRotationSpeed = 5f;
    [SerializeField, Range(1f, 10f)] private float _verticalRotationSpeed = 2f;
    [SerializeField] private float _maxCameraAngle = 40f;
    [SerializeField] private float _minCameraAngle = -40f;
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
        Quaternion targetRotation = Quaternion.Euler(0f, _target.eulerAngles.y, 0f);

        _verticalRotation -= mouseY * _verticalRotationSpeed;
        _verticalRotation = Mathf.Clamp(_verticalRotation, _minCameraAngle, _maxCameraAngle);

        Quaternion verticalRotation = Quaternion.Euler(_verticalRotation, 0f, 0f);

        transform.position = Vector3.Lerp(transform.position, _target.position + targetRotation * verticalRotation * _offset, Time.deltaTime * _horizontalRotationSpeed);
        transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation * verticalRotation, Time.deltaTime * _horizontalRotationSpeed);
    }
}
