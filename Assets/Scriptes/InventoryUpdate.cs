using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUpdate : MonoBehaviour
{
    [SerializeField] private GameObject _itemPrefab;
    [SerializeField] private Transform _itemPanelTransform;

    
    public List<ItemData> Inventory = new();

    public void AddItem(ItemData GivenItem)
    {
        if (!Inventory.Contains(GivenItem))
        {
            Inventory.Add(GivenItem);
        }
        
        RenderInventory();
    }
    
    public void RemoveItem(ItemData RemoveItem)
    {
        if (!Inventory.Contains(RemoveItem))
        {
            Inventory.Remove(RemoveItem);
        }
        
        RenderInventory();
    }

    public void RenderInventory()
    {
        foreach (Transform child in _itemPanelTransform)
        {
            Destroy(child.gameObject);
        }

        foreach (ItemData Item in Inventory)
        {
            GameObject instantiate = Instantiate(_itemPrefab, _itemPanelTransform);
            instantiate.GetComponent<Image>().sprite = Item.ItemImage;
        }
    }
}
