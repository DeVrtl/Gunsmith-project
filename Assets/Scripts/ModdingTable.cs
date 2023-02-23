using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ModdingTable : MonoBehaviour
{
    [SerializeField] private List<Weapon> _weapons;
    [SerializeField] private List<AttachmentView> _attachmentViews;
    [SerializeField] private List<AttachmentModding> _attachmentModdings;
    [SerializeField] private WeaponView _weaponTemplate;
    [SerializeField] private Button _done;
    [SerializeField] private GameObject _itemContainer;
    [SerializeField] private GameObject _attachmentsUI;

    private Attachment _spawnedAttachment;
    private WeaponView _weaponView;
    private AttachmentView _attachmentView;

    public List<AttachmentView> AttachmentViews { get; private set; } = new List<AttachmentView>();
    public Weapon Weapon { get; private set; }
    public List<Attachment> Attachments { get; private set; } = new List<Attachment>();

    private void Start()
    {
        for (int i = 0; i < _weapons.Count; i++)
        {
            AddItem(_weapons[i]);
        }
    }

    private void OnDisable()
    {
        _weaponView.WeaponSelected -= OnWeaponSelected;

        if (_attachmentView == null)
        {
            return;
        }

        _attachmentView.AttachmentSelected -= OnAttachmentSelected;
    }

    private void AddItem(Weapon weapon)
    {
        _weaponView = Instantiate(_weaponTemplate, _itemContainer.transform);
        _weaponView.WeaponSelected += OnWeaponSelected;
        _weaponView.Render(weapon);
    }

    private void OnAttachmentSelected(AttachmentView attachmentView)
    {
        if (Attachments.Count == 0)
        {
            _spawnedAttachment = Weapon.InstantiateAttachment(attachmentView.Attachment, Weapon.transform);
            Attachments.Add(_spawnedAttachment);
        }

        if (_spawnedAttachment.Type == attachmentView.Attachment.Type)
        {
            Destroy(_spawnedAttachment.gameObject);
            Attachments.Remove(_spawnedAttachment);
            _spawnedAttachment = Weapon.InstantiateAttachment(attachmentView.Attachment, Weapon.transform);
            Attachments.Add(_spawnedAttachment);
        }

        if (_spawnedAttachment.Type != attachmentView.Attachment.Type)
        {
            Attachment attachment = Weapon.InstantiateAttachment(attachmentView.Attachment, Weapon.transform);

            for (int i = 0; i < Attachments.Count; i++)
            {
                if (attachment.Type == Attachments[i].Type)
                {
                    Attachments.Remove(attachment);
                    Destroy(Attachments[i].gameObject);
                    Attachments.Remove(Attachments[i]);
                }
            }

            Attachments.Add(attachment);
        }
    }

    private void OnWeaponSelected(Weapon weapon)
    {
        Weapon = weapon;
        Weapon.gameObject.AddComponent<GrabRotation>();

        WeaponView[] weaponViews = _itemContainer.GetComponentsInChildren<WeaponView>();

        foreach (var weaponView in weaponViews)
        {
            Destroy(weaponView.gameObject);
        }

        _attachmentsUI.SetActive(true);
        _done.gameObject.SetActive(true);

        for (int allAtachmentViews = 0; allAtachmentViews < _attachmentViews.Count; allAtachmentViews++)
        {
            if (_attachmentViews[allAtachmentViews].WeaponType == weapon.Type)
            {
                _attachmentView = Instantiate(_attachmentViews[allAtachmentViews], _itemContainer.transform);
                _attachmentView.gameObject.SetActive(false);
                AttachmentViews.Add(_attachmentView);
                _attachmentView.AttachmentSelected += OnAttachmentSelected;

                for (int attachmentModding = 0; attachmentModding < _attachmentModdings.Count; attachmentModding++)
                {
                    if (_attachmentModdings[attachmentModding].Type == _attachmentView.Type)
                    {
                        _attachmentModdings[attachmentModding].AddView(_attachmentView);
                    }
                }
            }
        }
    }
}