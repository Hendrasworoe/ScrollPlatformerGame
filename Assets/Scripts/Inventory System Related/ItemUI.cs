using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ItemUI : MonoBehaviour
{
    [SerializeField] private Image _itsIcon;
    [SerializeField] private TMP_Text _itsLabel;
    [SerializeField] private Button _removeThisButton;

    public void Set(Item item)
    {
        _itsIcon.sprite = item.icon;
        _itsLabel.text = item.displayName;
        _removeThisButton.onClick.AddListener(() => InventorySystem.Instance.Remove(item));
    }
}
