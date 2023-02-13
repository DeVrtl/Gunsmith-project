using UnityEngine;
using UnityEngine.UI;

public class WeaponModingCard : MonoBehaviour
{
    [SerializeField] private ModdingTable _moddingTable;
    [SerializeField] private Transform _tradingPoint;
    [SerializeField] private Button _startBuilding;
    [SerializeField] private Button _done;
    [SerializeField] private GameObject _attachmentsUI;
    [SerializeField] private CanvasGroup _weaponModingGroup;
    [SerializeField] private CustomerOrder _customerOrder;
    [SerializeField] private CinemachineSwitcher _switcher;
    [SerializeField] private CinemachineCameraPositionChecker _cameraPositionChecker;

    private void OnEnable()
    {
        _startBuilding.onClick.AddListener(OnStartBuildingButtonClick);
        _done.onClick.AddListener(OnDoneButtonClick);
    }

    private void OnDisable()
    {
        _startBuilding.onClick.RemoveListener(OnStartBuildingButtonClick);
        _done.onClick.RemoveListener(OnDoneButtonClick);
    }

    private void OnStartBuildingButtonClick()
    {
        _weaponModingGroup.alpha = 1;
        _weaponModingGroup.interactable = true;
        _switcher.SwitchPriority();
        _startBuilding.gameObject.SetActive(false);
    }

    private void OnDoneButtonClick()
    {
        _weaponModingGroup.alpha = 0;
        _weaponModingGroup.interactable = false;

        _switcher.SwitchPriority();

        _done.gameObject.SetActive(false);
        _attachmentsUI.gameObject.SetActive(false);

        _moddingTable.Weapon.transform.position = _tradingPoint.position;
        _moddingTable.Weapon.transform.rotation = _tradingPoint.rotation;
        Destroy(_moddingTable.Weapon.GetComponent<GrabRotation>());

        _customerOrder.enabled = true;
        _cameraPositionChecker.enabled = true;
    }
}
