using UnityEngine;

public class Attachment : MonoBehaviour
{
    [SerializeField] private AttachmentName _name;
    [SerializeField] private WeaponType _weaponType;
    [SerializeField] private AttachmentType _type;

    public AttachmentType Type => _type;
    public AttachmentName Name => _name; 
}
