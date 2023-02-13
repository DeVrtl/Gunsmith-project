using UnityEngine;
using Cinemachine;

public class CinemachineSwitcher : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera _shop;
    [SerializeField] private CinemachineVirtualCamera _buildigTable;
    [SerializeField] private int _highPriority;
    [SerializeField] private int _lowPriority;

    private bool _isMainCamer = true;

    public void SwitchPriority()
    {
        if (_isMainCamer)
        {
            _buildigTable.Priority = _highPriority;
            _shop.Priority = _lowPriority;
        }
        else
        {
            _buildigTable.Priority = _lowPriority;
            _shop.Priority = _highPriority;
        }

        _isMainCamer = !_isMainCamer;
    }
}
