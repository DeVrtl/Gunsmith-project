using System.Collections.Generic;
using UnityEngine;

public class OrderGenerator : MonoBehaviour
{
    [SerializeField] private Catalog _catalog;
    [SerializeField] private Transform _preview;

    private Weapon _weapon;
    private List<Attachment> _attachments = new List<Attachment>();
    private List<AttachmentType> _attachmentTypes = new List<AttachmentType>();

    private void OnEnable()
    {
        WeaponType weaponType = _catalog.GetRandomWeaponType();

        InstantiateWeapon(weaponType);
        AdoptAndRotateWeapon();

        _attachmentTypes = _catalog.GetRandomAttachmentTypes(_weapon);

        for (int i = 0; i < _attachmentTypes.Count; i++)
        {
            _attachments.Add(_catalog.GetAttachment(_weapon.Type, _attachmentTypes[i]));
        }

        _weapon.InstantiateAttachments(_attachments, _weapon.transform);
    }


    private void OnDisable()
    {
        Destroy(_weapon.gameObject);
        _attachments.Clear();
    }
    
    public Order Generate()
    {
        Order order = new Order(_weapon, _attachments);
        return order;
    }

    private void InstantiateWeapon(WeaponType weaponType)
    {
        _weapon = _catalog.GetRandomWeapon(weaponType);
        _weapon = Instantiate(_weapon, _preview.position, Quaternion.identity);
    }

    private void AdoptAndRotateWeapon()
    {
        _weapon.transform.Rotate(new Vector3(0, 90));
        _weapon.transform.SetParent(_preview);
    }
}
