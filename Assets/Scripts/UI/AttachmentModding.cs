using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AttachmentModding : MonoBehaviour
{
    [SerializeField] private AttachmentType _type;
    [SerializeField] private Button _button;
    [SerializeField] private Image _image;
    [SerializeField] private GameObject _itemContainer;
    [SerializeField] private ModdingTable _moddingTable;

    public List<AttachmentView> Views { get; private set; } = new List<AttachmentView>();

    public AttachmentType Type => _type;

    private void OnEnable()
    {
        _button.onClick.AddListener(OnButtonClick);
    }

    private void OnDisable()
    {
        _button.onClick.RemoveListener(OnButtonClick);
    }
    
    public void ReplaceSprite(Image image)
    {
        _image.sprite = image.sprite;
    }

    public void AddView(AttachmentView view)
    {
        Views.Add(view);
        view.SetModding(this);
    }

    private void OnButtonClick()
    {
        for (int i = 0; i < _moddingTable.AttachmentViews.Count; i++)
        {
            _moddingTable.AttachmentViews[i].gameObject.SetActive(false);
        }

        for (int i = 0; i < _moddingTable.AttachmentViews.Count; i++)
        {
            if (_moddingTable.AttachmentViews[i].Type == _type)
            {
                _moddingTable.AttachmentViews[i].gameObject.SetActive(true);
            }
        }
    }
}