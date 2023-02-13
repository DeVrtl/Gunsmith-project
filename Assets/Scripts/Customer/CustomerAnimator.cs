using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Animator))]
public class CustomerAnimator : MonoBehaviour
{
    private Animator _animator;

    public event UnityAction ClipEnded;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    public void Play(CustomerAnimations state)
    {
        _animator.Play(state.ToString());
    }

    public void InvokeClipEnded()
    {
        ClipEnded?.Invoke();
    }
}
