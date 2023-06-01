using System;
using Services.DependencyContainer;
using UI;
using UnityEngine;

public class ItemTaker : MonoBehaviour
{
    public InventoryPresenter InventoryPresenter { get; set; }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.TryGetComponent(out DynamicItem dynamicItem))
        {
            InventoryPresenter.AddItemToInventory(dynamicItem);
        }
    }
}