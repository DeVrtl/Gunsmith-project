using UnityEngine;
using UnityEngine.UI;

public class WeaponModingCard : MonoBehaviour
{
    [SerializeField] private Button _startBuilding;
    [SerializeField] private Button _done;
    [SerializeField] private CanvasGroup _weaponModingGroup;
    [SerializeField] private CinemachineSwitcher _switcher;

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
        _done.gameObject.SetActive(true);
        _startBuilding.gameObject.SetActive(false);
    }

    private void OnDoneButtonClick()
    {
        _weaponModingGroup.alpha = 0;
        _weaponModingGroup.interactable = false;
        _switcher.SwitchPriority();
        _done.gameObject.SetActive(false);
    }
}
