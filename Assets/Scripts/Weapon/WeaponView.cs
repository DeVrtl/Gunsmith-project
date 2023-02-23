using UnityEngine;
using UnityEngine.Events;

public class WeaponView : View
{
    [SerializeField] private Transform _weaponSapwnPoint;

    private Weapon _weapon;

    public event UnityAction<Weapon> WeaponSelected;

    private void OnEnable()
    {
        Select.onClick.AddListener(OnWeaponTemplateSelectButtonClicked);
    }

    private void OnDisable()
    {
        Select.onClick.RemoveListener(OnWeaponTemplateSelectButtonClicked);
    }

    public void Render(Weapon weapon)
    {
        _weapon = weapon;

        Icon.sprite = weapon.Icon;
    }

    public override void OnWeaponTemplateSelectButtonClicked()
    {
        Weapon weapon = Instantiate(_weapon, _weaponSapwnPoint.position, Quaternion.identity);
        weapon.transform.Rotate(new Vector3(0, 90));
        WeaponSelected?.Invoke(weapon);
    }
}
