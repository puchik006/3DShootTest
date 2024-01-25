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

        _characterController.MoveCharacter(horizontalInput, verticalInput);
        _characterController.RotateCharacter(mouseX);

        _animationHandler.Walk(verticalInput);

        _thirdPersonCamera.MoveCamera(mouseY);
    }

}

