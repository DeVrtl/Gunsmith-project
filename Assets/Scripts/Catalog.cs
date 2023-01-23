using System;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;

public class Catalog : MonoBehaviour
{
    [SerializeField] private List<CatalogSection> _section;

    public Attachment GetAttachment(WeaponType weaponType, AttachmentType attachmentType)
    {
        for (int sectionNumber = 0; sectionNumber < _section.Count; sectionNumber++)
        {
            if (_section[sectionNumber].WeaponType == weaponType)
            {
                List<Attachment> attachmentTemplates = _section[sectionNumber].AttachmentTemplate;
                for (int attachmentNumber = 0; attachmentNumber < attachmentTemplates.Count; attachmentNumber++)
                {
                    if (attachmentTemplates[attachmentNumber].Type == attachmentType)
                    {
                        return attachmentTemplates[attachmentNumber];
                    }
                }
            }
        }

        return null;
    }

    public WeaponType GetRandomWeaponType()
    {
        WeaponType weaponType = _section[UnityEngine.Random.Range(0, _section.Count)].WeaponType;

        return weaponType;
    }

    public Weapon GetRandomWeapon()
    {
        CatalogSection catalogSection = _section.Find(s => GetRandomWeaponType() == s.WeaponTemplates[UnityEngine.Random.Range(0, s.WeaponTemplates.Count)].Type);
        Weapon weapon = catalogSection.WeaponTemplates[UnityEngine.Random.Range(0, catalogSection.WeaponTemplates.Count)];

        return weapon;
    }

    public List<AttachmentType> GetRandomAttachmentTypes()
    {
        int attachmentsCount = UnityEngine.Random.Range(0, GetRandomWeapon().AttachmentPlaces.Count);

        List<AttachmentType> attachmentTypes = new List<AttachmentType>();
        List<AttachmentPlace> attachmentPlace = GetRandomWeapon().AttachmentPlaces;

        for (int i = attachmentsCount; i < attachmentPlace.Count; i++)
        {
            attachmentTypes.Add(attachmentPlace[i].Type); 
        }

        return attachmentTypes;
    }
}

[Serializable]
public class CatalogSection
{
    [SerializeField] private WeaponType _weaponType;
    [SerializeField] private List<Weapon> _weaponTemplates;
    [SerializeField] private List<Attachment> _attachmentTemplate;

    public List<Attachment> AttachmentTemplate => _attachmentTemplate;
    public WeaponType WeaponType => _weaponType;
    public List<Weapon> WeaponTemplates => _weaponTemplates;
}