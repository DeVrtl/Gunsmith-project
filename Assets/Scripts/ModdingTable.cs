using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ModdingTable : MonoBehaviour
{
    [SerializeField] private List<Weapon> _weapons;
    [SerializeField] private List<Attachment> _attachments;
    [SerializeField] private WeaponView _weaponTemplate; 
    [SerializeField] private AttachmentView _attachmentTemplate;
    [SerializeField] private GameObject _itemContainer;

    Weapon _weapon;

    private void OnDisable()
    {
        _weaponTemplate.WeaponSelected -= OnWeaponSelected;
    }

    private void Start()
    {
        for (int i = 0; i < _weapons.Count; i++)
        {
            AddItem(_weapons[i]);
        }
    }

    private void AddItem(Weapon weapon)
    {
        WeaponView view = Instantiate(_weaponTemplate, _itemContainer.transform);
        view.WeaponSelected += OnWeaponSelected;
        view.Render(weapon);
    }

    private void OnWeaponSelected(Weapon weapon)
    {
        _weapon = weapon;

        WeaponView[] weaponViews = _itemContainer.GetComponentsInChildren<WeaponView>();

        for (int i = 0; i < weaponViews.Length; i++)
        {
            Destroy(weaponViews[i].gameObject);
        }
    }
}