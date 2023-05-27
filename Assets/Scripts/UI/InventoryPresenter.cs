using System;
using UnityEngine;

namespace UI
{
    public class InventoryPresenter : MonoBehaviour
    {
        public event Action<DynamicItem> ItemAdded;
        
        private Inventory _inventory = new Inventory();

        public void AddItemToInventory(DynamicItem dynamicItem)
        {
            Item item = ItemDatabase.GetItem(dynamicItem.Index);
            
            _inventory.AddItem(item);
            
            ItemAdded?.Invoke(dynamicItem);
        }

        public void RemoveItemFromInventory(int itemId)
        {
            Item item = ItemDatabase.GetItem(itemId);
            
            _inventory.RemoveItem(item);
        }
    }
}