using UnityEngine;

public class PlayerInput: MonoBehaviour
{
    private SimpleCharacterController _characterController;
    private AnimationHandler _animationHandler;
    [SerializeField] private ThirdPersonCamera _thirdPersonCamera;

    private void OnValidate()
    {
        _characterController = GetComponent<SimpleCharacterController>();
        _animationHandler = GetComponent<AnimationHandler>();
    }

    private void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");
        bool isShiftPressed = Input.GetKey(KeyCode.LeftShift);

        _characterController.Move(horizontalInput, verticalInput);
        _characterController.Rotate(mouseX);
        _characterController.Run(isShiftPressed);

        _animationHandler.Walk(verticalInput);
        _animationHandler.Run(isShiftPressed);

        _thirdPersonCamera.MoveCamera(mouseY);
    }

}

