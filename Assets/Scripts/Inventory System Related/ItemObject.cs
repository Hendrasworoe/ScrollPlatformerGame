using UnityEngine;

public class ItemObject : MonoBehaviour, iInteractable
{
    public Item referenceItem;

    public void IntractIt()
    {
        PickupItem();
    }

    private void PickupItem()
    {
        if (InventorySystem.Instance.CanPickUpItem())
        {
            InventorySystem.Instance.Add(referenceItem);
            Destroy(gameObject);
        }
        else
        {
            DialogueManager.Instance.dialogueSystem.Begin("FullItemNotif");
        }
    }
}
