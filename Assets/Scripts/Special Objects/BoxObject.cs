using UnityEngine;

public class BoxObject : MonoBehaviour, iInteractable
{
    [SerializeField] private Item _itemContain;
    [SerializeField] private Sprite _openedBoxSprite;

    private bool _isOpen;

    public void IntractIt()
    {
        if (!_isOpen)
        {
            _isOpen = true;
            GetComponent<SpriteRenderer>().sprite = _openedBoxSprite;

            if (!_itemContain)
            {
                DialogueManager.Instance.dialogueSystem.Begin("EmptyBoxNotif");
                Destroy(this);
            }
        }
        else
        {
            InventorySystem.Instance.Add(_itemContain);
            DialogueManager.Instance.dialogueSystem.Begin("PickingFromBox");
            Destroy(this);
        }
    }
}
