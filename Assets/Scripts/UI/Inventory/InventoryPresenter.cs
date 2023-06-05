using System;
using UnityEngine;

namespace UI
{
    public class InventoryPresenter
    {
        public event Action<DynamicItem> ItemAdded;
        public event Action<DynamicItem> ItemRemoved;

        private readonly Inventory _inventory;
        
        public InventoryPresenter(Inventory inventory)
        {
            _inventory = inventory;
        }

        public void AddItemToInventory(DynamicItem dynamicItem)
        {
            Item item = ItemDatabase.GetItem(dynamicItem.Index);
            
            _inventory.AddItem(item);
            
            ItemAdded?.Invoke(dynamicItem);
        }

        public void RemoveItemFromInventory(DynamicItem dynamicItem)
        {
            Debug.Log(dynamicItem);
            Item item = ItemDatabase.GetItem(dynamicItem.Index);
            
            _inventory.RemoveItem(item);

            ItemRemoved?.Invoke(dynamicItem);
        }
    }
}