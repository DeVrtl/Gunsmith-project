using System;
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

    public Weapon GetRandomWeapon(WeaponType weaponType)
    {
        CatalogSection catalogSection = null;

        for (int sectionNumber = 0; sectionNumber < _section.Count; sectionNumber++)
        {
            if (_section[sectionNumber].WeaponType == weaponType)
            {
                for (int weaponNumber = 0; weaponNumber < _section[sectionNumber].WeaponTemplates.Count; weaponNumber++)
                {
                    if (_section[sectionNumber].WeaponTemplates[weaponNumber].Type == weaponType)
                    {
                        catalogSection = _section[sectionNumber];
                    }
                }
            }
        }

        Weapon weapon = catalogSection.WeaponTemplates[UnityEngine.Random.Range(0, catalogSection.WeaponTemplates.Count)];

        return weapon;
    }

    public List<AttachmentType> GetRandomAttachmentTypes(Weapon weapon)
    {
        int attachmentsCount = UnityEngine.Random.Range(0, weapon.AttachmentPlaces.Count);

        List<AttachmentType> attachmentTypes = new List<AttachmentType>();
        List<AttachmentPlace> attachmentPlace = weapon.AttachmentPlaces;

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