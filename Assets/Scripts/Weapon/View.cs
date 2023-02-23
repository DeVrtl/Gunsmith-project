using UnityEngine;
using UnityEngine.UI;

public abstract class View : MonoBehaviour
{
    [SerializeField] private Image _icon;
    [SerializeField] private Button _select;

    public Image Icon => _icon;
    public Button Select => _select;

    public abstract void OnWeaponTemplateSelectButtonClicked();
}
