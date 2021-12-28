using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

[Serializable]
public class InventoryCell
{
    public Item item;
}

public class Inventory : MonoBehaviour
{
    [SerializeField] public List<Item> items = new List<Item>();
    [SerializeField] private int maxSize = 6;
    [SerializeField] public UnityEvent OnInventoryChanged;
    public bool AddItem(Item item)
    {
        if (items.Count >= maxSize) return false;
        items.Add(item);
        OnInventoryChanged.Invoke();
        return true;
    }

    public bool RemoveItem(int id)
    {
        for (var i = 0; i < GetSize(); i++)
        {
            if (items[i].id == id)
            {
                items[i] = null;
                OnInventoryChanged.Invoke();
                return true;
            }
        }
        return false;
    }

    public Item GetItem(int i)
    {
        return i < items.Count ? items[i] : null;
    }

    public int GetSize()
    {
        return items.Count;
    }
}
