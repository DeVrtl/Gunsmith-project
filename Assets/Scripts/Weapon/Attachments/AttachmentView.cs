using UnityEngine;
using UnityEngine.Events;

public class AttachmentView : View
{
    [SerializeField] private Attachment _attachment;
    [SerializeField] private AttachmentType _type;
    [SerializeField] private WeaponType _weaponType;

    private AttachmentModding _modding;

    public bool IsSpawned { get; private set; } = false;

    public WeaponType WeaponType => _weaponType;
    public AttachmentType Type => _type;
    public Attachment Attachment => _attachment;

    public event UnityAction<AttachmentView> AttachmentSelected;

    private void OnEnable()
    {
        Select.onClick.AddListener(OnWeaponTemplateSelectButtonClicked);
    }

    private void OnDisable()
    {
        Select.onClick.RemoveListener(OnWeaponTemplateSelectButtonClicked);
    }

    public void SetModding(AttachmentModding modding)
    {
        _modding = modding;
    } 

    public override void OnWeaponTemplateSelectButtonClicked()
    {
        AttachmentSelected?.Invoke(this);

        _modding.ReplaceSprite(Icon);
    }
}
