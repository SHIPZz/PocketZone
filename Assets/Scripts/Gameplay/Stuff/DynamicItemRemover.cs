using UI;
using UnityEngine;

namespace Gameplay.Stuff
{
    public class DynamicItemRemover
    {
        private InventoryPresenter _inventoryPresenter;

        public DynamicItemRemover(InventoryPresenter inventoryPresenter)
        {
            _inventoryPresenter = inventoryPresenter;
        }
        
        public void Remove(DynamicItem dynamicItem)
        {
            Debug.Log(dynamicItem);
            Debug.Log(_inventoryPresenter);
            _inventoryPresenter.RemoveItemFromInventory(dynamicItem);
        }
    }
}
