using System;
using Services.DependencyContainer;
using UI;
using UnityEngine;

public class ItemTaker : MonoBehaviour
{
    private InventoryPresenter _inventoryPresenter;
    
    private void Start()
    {
        _inventoryPresenter = ServiceLocator.Get<InventoryPresenter>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.TryGetComponent(out DynamicItem dynamicItem))
        {
            _inventoryPresenter.AddItemToInventory(dynamicItem);
        }
    }
}