using UnityEngine;

[RequireComponent(typeof(Animator))]
public class CustomerAnimator : MonoBehaviour
{
    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    public void Play(CustomerAnimations state)
    {
        _animator.Play(state.ToString());
    }
}
