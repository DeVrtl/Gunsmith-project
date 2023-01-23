using System.Collections.Generic;
using UnityEngine;

public class Order 
{
    private WeaponType _weaponType;
    private List<AttachmentType> _attachmentTypes;
    private GameObject _preview;

    public Order(WeaponType weaponType, List<AttachmentType> attachmentTypes, GameObject preview)
    {
        _weaponType = weaponType;
        _attachmentTypes = attachmentTypes;
        _preview = preview;
    }
}
