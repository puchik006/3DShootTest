using UnityEngine;

public class AnimationHandler: MonoBehaviour
{
    private const string _isWalkKey = "IsWalk";
    private const string _isRunKey = "IsRun";
    private const string _isJumpKey = "IsJump";

    private Animator _animator;

    private void OnValidate() => _animator = GetComponent<Animator>();

    public void Walk(float forwardVector)
    {
        if (forwardVector > 0)
        {
            _animator.SetBool(_isWalkKey, true);
            Debug.Log("walk");
        }
        else
        {
            _animator.SetBool(_isWalkKey, false);
            Debug.Log("not walk");
        }
    }
}
