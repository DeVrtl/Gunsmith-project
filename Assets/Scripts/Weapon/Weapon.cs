using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] private Sprite _icon;
    [SerializeField] private List<AttachmentPlace> _attachmentPlaces;
    [SerializeField] private WeaponType _type;
    [SerializeField] private WeaponName _name;

    public WeaponType Type => _type;
    public List<AttachmentPlace> AttachmentPlaces => _attachmentPlaces;
    public Sprite Icon => _icon;
    public WeaponName Name => _name; 

    public void InstantiateAttachments(List<Attachment> attachments, Transform parent)
    {
        foreach (var attachment in attachments)
        {
            foreach (var attachmentPlace in _attachmentPlaces)
            {
                if (attachment.Type == attachmentPlace.Type)
                {
                    Attachment attachmentSpawned = Instantiate(attachment, attachmentPlace.transform.position, Quaternion.identity, parent);
                    attachmentSpawned.transform.Rotate(new Vector3(0, 90));
                }
            }
        }
    }

    public Attachment InstantiateAttachment(Attachment attachment, Transform parent)
    {
        foreach (var attachmentPlace in _attachmentPlaces)
        {
            if (attachment.Type == attachmentPlace.Type)
            {
                Attachment attachmentSpawned = Instantiate(attachment, attachmentPlace.transform.position, Quaternion.identity, parent);
                attachmentSpawned.transform.rotation = parent.rotation;

                return attachmentSpawned;
            }
        }

        return null;
    }
}