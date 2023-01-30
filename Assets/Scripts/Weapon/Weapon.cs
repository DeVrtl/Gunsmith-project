using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] private Sprite _icon;
    [SerializeField] private List<AttachmentPlace> _attachmentPlaces;
    [SerializeField] private WeaponType _type;

    public WeaponType Type => _type;
    public List<AttachmentPlace> AttachmentPlaces => _attachmentPlaces;
    public Sprite Icon => _icon; 

    public void InstantiateAttachments(List<Attachment> attachments, Transform parent)
    {
        foreach (var attachment in attachments)
        {
            foreach (var attachmentPlace in _attachmentPlaces)
            {
                if (attachment.Type == attachmentPlace.Type)
                {
                    Instantiate(attachment, attachmentPlace.transform.position, Quaternion.identity, parent);
                }
            }
        }
    }
}