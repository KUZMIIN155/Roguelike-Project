using UnityEngine;
using UnityEngine.UI;

public class InventoryItemPresenter : MonoBehaviour
{
    [SerializeField] private Text _nameField;
    [SerializeField] private Image _iconField;

    public void Render(IItem item)
    {
        _nameField.text = item.Name;
        _iconField.sprite = item.UIIcon;
    }
}
