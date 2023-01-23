using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(CustomerPusher), typeof(CustomerAnimator), typeof(CustomerCollisionHandler))]
[RequireComponent(typeof(CustomerRotator))]
public class Customer : MonoBehaviour
{
    [SerializeField] private Image _textCloud;
    [SerializeField] private Button _startBuilding;

    private CustomerPusher _pusher;
    private CustomerAnimator _animator;
    private CustomerCollisionHandler _collisionHandler;
    private CustomerRotator _rotator;

    private void Awake()
    {
        _pusher = GetComponent<CustomerPusher>();
        _animator = GetComponent<CustomerAnimator>();
        _collisionHandler = GetComponent<CustomerCollisionHandler>();
        _rotator = GetComponent<CustomerRotator>();
    }

    private void OnEnable()
    {
        _collisionHandler.Passed += OnPassed;
    }

    private void OnDisable()
    {
        _collisionHandler.Passed -= OnPassed;
    }

    private void OnPassed()
    {
        _pusher.enabled = false;

        _animator.Play(CustomerAnimations.Idle);

        _rotator.enabled = true;

        _textCloud.gameObject.SetActive(true);
        _startBuilding.gameObject.SetActive(true);
    }
}
