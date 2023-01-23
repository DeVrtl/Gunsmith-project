using System.Collections.Generic;
using UnityEngine;

public class OrderGenerator : MonoBehaviour
{
    [SerializeField] private Catalog _catalog;
    [SerializeField] private Transform _preview;

    private void Awake()
    {
        Weapon weapon = _catalog.GetRandomWeapon();
        weapon = Instantiate(weapon, _preview.position, Quaternion.identity);
        weapon.transform.SetParent(_preview);

        List<AttachmentType> attachmentTypes = _catalog.GetRandomAttachmentTypes();
        List<Attachment> attachments = new List<Attachment>();

        for (int i = 0; i < attachmentTypes.Count; i++)
        {
            attachments.Add(_catalog.GetAttachment(weapon.Type, attachmentTypes[i]));
        }

        weapon.InstantiateAttachments(attachments, weapon.transform);
    }

    public Order Generate()
    {
        Order order = new Order(_catalog.GetRandomWeaponType(), _catalog.GetRandomAttachmentTypes(), _catalog.GetRandomWeapon().gameObject);
        return order;
    }
}
