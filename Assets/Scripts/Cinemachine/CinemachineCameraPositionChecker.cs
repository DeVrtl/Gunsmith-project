using UnityEngine;
using Cinemachine;

public class CinemachineCameraPositionChecker : MonoBehaviour
{
    [SerializeField] private CustomerAnimator _customerAnimator;
    [SerializeField] private CinemachineVirtualCamera _shop;

    private void Update()
    {
        if (_shop.transform.position == _shop.State.FinalPosition)
        {
            _customerAnimator.Play(CustomerAnimations.Thinking);
        }

        enabled = false;
    }
}
