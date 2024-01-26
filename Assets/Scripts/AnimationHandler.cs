using UnityEngine;

public class AnimationHandler: MonoBehaviour
{
    private const string _isWalkKey = "IsWalk";
    private const string _isRunKey = "IsRun";
    private Animator _animator;

    private void OnValidate() => _animator = GetComponent<Animator>();

    public void Walk(float forwardVector) => _animator.SetBool(_isWalkKey, forwardVector > 0);
    public void Run(bool isShiftPressed) => _animator.SetBool(_isRunKey, isShiftPressed);
}
