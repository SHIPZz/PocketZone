using UI;
using UnityEngine;

public class ItemTaker : MonoBehaviour
{
    // [SerializeField] private InventoryPresenter _inventoryPresenter;
    
    private InventoryPresenter _inventoryPresenter;

    private void Awake()
    {
        _inventoryPresenter = GetComponent<InventoryPresenter>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.TryGetComponent(out DynamicItem dynamicItem))
        {
            _inventoryPresenter.AddItemToInventory(dynamicItem);
        }
    }
}