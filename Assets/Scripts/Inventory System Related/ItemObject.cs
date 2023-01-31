using UnityEngine;

public class ItemObject : MonoBehaviour
{
    public Item referenceItem;

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player") && Input.GetButton("Submit"))
        {
            Debug.Log("Item Picked");
            PickupItem();
        }
    }

    private void PickupItem()
    {
        InventorySystem.Instance.Add(referenceItem);
        Destroy(gameObject);
    }
}
