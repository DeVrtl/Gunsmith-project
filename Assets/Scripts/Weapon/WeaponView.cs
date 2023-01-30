using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class WeaponView : View
{
    [SerializeField] private Transform _weaponSapwnPoint;

    private Weapon _weapon;

    public event UnityAction<Weapon> WeaponSelected;

    private void OnEnable()
    {
        Select.onClick.AddListener(OnButtonClick);
    }

    private void OnDisable()
    {
        Select.onClick.RemoveListener(OnButtonClick);
    }

    public void Render(Weapon weapon)
    {
        _weapon = weapon;

        Icon.sprite = weapon.Icon;
    }

    public override void OnButtonClick()
    {
        Weapon weapon = Instantiate(_weapon, _weaponSapwnPoint.position, Quaternion.identity);
        weapon.transform.Rotate(new Vector3(0, 90));
        WeaponSelected?.Invoke(_weapon);
    }
}
