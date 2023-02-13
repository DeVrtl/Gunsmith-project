using System.Linq;
using UnityEngine;
using UnityEngine.Events;

public class CustomerOrder : MonoBehaviour
{
    [SerializeField] private ModdingTable _moddingTable;
    [SerializeField] private OrderGenerator _orderGenerator;

    public event UnityAction OrderFinished;
    public event UnityAction OrderIsNotFinished;
    public event UnityAction OrderFailed;

    public void Compare()
    {
        if (_moddingTable.Weapon.Name != _orderGenerator.Weapon.Name)
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
            foreach (var attachmentInOrder in _orderGenerator.Attachments)
            {
                if (attachmentInModdingTable.Name == attachmentInOrder.Name)
                {
                    OrderFinished?.Invoke();
                }
                else if (attachmentInModdingTable.Name != attachmentInOrder.Name)
                {
                    OrderIsNotFinished?.Invoke();
                }
            }
        }
    }
}