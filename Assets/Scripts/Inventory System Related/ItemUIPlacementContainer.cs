using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemUIPlacementContainer : MonoBehaviour
{
    [SerializeField] private GameObject _itemButtonPrefab;

    // Start is called before the first frame update
    void Start()
    {
        InventorySystem.Instance.onInventoryChangedEvent += OnUpdateInventory;
    }

    private void OnDestroy()
    {
        InventorySystem.Instance.onInventoryChangedEvent -= OnUpdateInventory;
    }

    private void OnUpdateInventory()
    {
        foreach (Transform t in transform)
        {
            Destroy(t.gameObject);
        }

        DrawInventory();
    }

    public void DrawInventory()
    {
        foreach (Item item in InventorySystem.Instance.inventory)
        {
            AddInventoryContainer(item);
        }
    }

    public void AddInventoryContainer(Item item)
    {
        GameObject obj = Instantiate(_itemButtonPrefab);
        obj.transform.SetParent(transform, false);

        ItemUI item_UI_detail = obj.GetComponent<ItemUI>();
        item_UI_detail.Set(item);
    }
}
