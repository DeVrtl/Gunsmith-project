using UnityEngine;

public class AttachmentPlace : MonoBehaviour
{
    [SerializeField] private AttachmentType _type;

    public AttachmentType Type => _type; 
}
