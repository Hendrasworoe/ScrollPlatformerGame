using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ItemUI : MonoBehaviour
{
    [SerializeField] private Image _itsIcon;
    [SerializeField] private TMP_Text _itsLabel;

    public void Set(Item item)
    {
        _itsIcon.sprite = item.icon;
        _itsLabel.text = item.displayName;
    }
}
