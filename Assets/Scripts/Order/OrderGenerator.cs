using System.Collections.Generic;
using UnityEngine;

public class OrderGenerator : MonoBehaviour
{
    [SerializeField] private Catalog _catalog;
    [SerializeField] private Transform _preview;

    private Weapon _weapon;
    private List<Attachment> _attachments = new List<Attachment>();
    private List<AttachmentType> _attachmentTypes = new List<AttachmentType>();

    public Weapon Weapon => _weapon;
    public List<Attachment> Attachments => _attachments;

    private void Awake()
    {
        WeaponType weaponType = _catalog.GetRandomWeaponType();

        _weapon = _catalog.GetRandomWeapon(weaponType);
        _weapon = Instantiate(_weapon, _preview.position, Quaternion.identity);
        _weapon.transform.Rotate(new Vector3(0, 90));
        _weapon.transform.SetParent(_preview);

        _attachmentTypes = _catalog.GetRandomAttachmentTypes(_weapon);

        for (int i = 0; i < _attachmentTypes.Count; i++)
        {
            _attachments.Add(_catalog.GetAttachment(_weapon.Type, _attachmentTypes[i]));
        }

        _weapon.InstantiateAttachments(_attachments, _weapon.transform);
    }
}
