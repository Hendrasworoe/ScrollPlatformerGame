using System;
using System.Collections.Generic;
using UnityEngine;

public class InventorySystem : MonoBehaviour
{
    private static InventorySystem _instance;
    public static InventorySystem Instance { get { return _instance; } }

    public List<Item> inventory { get; private set; }

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            _instance = this;
        }

        inventory = new List<Item>();
    }

    public event Action onInventoryChangedEvent;

    public void Add(Item addedItem)
    {
        // add clausa when inventory is full
        inventory.Add(addedItem);

        onInventoryChangedEvent();
    }

    public void Remove(Item removedItem)
    {
        inventory.Remove(removedItem);

        onInventoryChangedEvent();
    }
}
