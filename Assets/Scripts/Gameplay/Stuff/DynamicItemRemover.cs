using UI;
using UnityEngine;

namespace Gameplay.Stuff
{
    public class DynamicItemRemover
    {
        private readonly InventoryPresenter _inventoryPresenter;

        public DynamicItemRemover(InventoryPresenter inventoryPresenter)
        {
            _inventoryPresenter = inventoryPresenter;
        }
        
        public void Remove(DynamicItem dynamicItem)
        {
            _inventoryPresenter.RemoveItemFromInventory(dynamicItem);
        }
    }
}
