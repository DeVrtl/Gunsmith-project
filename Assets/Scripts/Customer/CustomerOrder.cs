using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

public class CustomerOrder : MonoBehaviour
{
    [SerializeField] private ModdingTable _moddingTable;
    [SerializeField] private OrderGenerator _orderGenerator;

    private List<AttachmentName> _attachmentNamesInOrder = new List<AttachmentName>();
    private List<AttachmentName> _attachmentNamesInTable = new List<AttachmentName>();

    public event UnityAction OrderFinished;
    public event UnityAction OrderIsNotFinished;
    public event UnityAction OrderFailed;

    public void Compare()
    {
        if (_moddingTable.Weapon.Name != _orderGenerator.Generate().Weapon.Name)
        {
            OrderFailed?.Invoke();
            return;
        }

        if (_moddingTable.Attachments.Count == 0)
        {
            OrderIsNotFinished?.Invoke();
            return;
        }

        foreach (var attachmentInModdingTable in _moddingTable.Attachments)
        {
            _attachmentNamesInTable.Add(attachmentInModdingTable.Name);

            foreach (var attachmentInOrder in _orderGenerator.Generate().Attachments)
            {
                _attachmentNamesInOrder.Add(attachmentInOrder.Name);
            }
        }

        var resualt = _attachmentNamesInTable.Except(_attachmentNamesInOrder);

        if (resualt.Count() == 0)
        {
            OrderFinished?.Invoke();
        }
        else
        {
            OrderIsNotFinished?.Invoke();
        }
    }
}