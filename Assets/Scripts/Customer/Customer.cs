using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(CustomerPusher), typeof(CustomerAnimator), typeof(CustomerCollisionHandler))]
[RequireComponent(typeof(CustomerRotator), typeof(CustomerOrder))]
public class Customer : MonoBehaviour
{
    [SerializeField] private Transform _customerHands;
    [SerializeField] private ModdingTable _moddingTable;
    [SerializeField] private Image _textCloud;
    [SerializeField] private Button _startBuilding;
    [SerializeField] private GameObject _failureCard;

    private CustomerOrder _customerOrder;
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
        _customerOrder = GetComponent<CustomerOrder>();
    }

    private void OnEnable()
    {
        _collisionHandler.Passed += OnPassed;
        _animator.ClipEnded += OnClipEnded;
        _customerOrder.OrderFinished += OnOrderFinished;
        _customerOrder.OrderIsNotFinished += OnOrderIsNotFinished;
        _customerOrder.OrderFailed += OnOrderFailed;
    }

    private void OnDisable()
    {
        _collisionHandler.Passed -= OnPassed;
        _animator.ClipEnded -= OnClipEnded;
        _customerOrder.OrderFinished -= OnOrderFinished;
        _customerOrder.OrderIsNotFinished -= OnOrderIsNotFinished;
        _customerOrder.OrderFailed -= OnOrderFailed;
    }

    public void ShowFailuerCard()
    {
        _failureCard.gameObject.SetActive(true);
    }

    private void OnClipEnded()
    {
        transform.Rotate(0, 90, 0);
        _textCloud.gameObject.SetActive(false);
        _moddingTable.Weapon.transform.position = _customerHands.position;
        _moddingTable.Weapon.transform.rotation = _customerHands.rotation;
        _moddingTable.Weapon.transform.SetParent(_customerHands);
    }

    private void OnPassed()
    {
        _pusher.enabled = false;

        _animator.Play(CustomerAnimations.Idle);

        _rotator.Rotate(180f);

        _textCloud.gameObject.SetActive(true);
        _startBuilding.gameObject.SetActive(true);
    }

    private void OnOrderFinished()
    {
        _animator.Play(CustomerAnimations.JoyfulJump);
    }

    private void OnOrderIsNotFinished()
    {
        _animator.Play(CustomerAnimations.Shrugging);
    }

    private void OnOrderFailed()
    {
        _animator.Play(CustomerAnimations.Angry);
    }
}
