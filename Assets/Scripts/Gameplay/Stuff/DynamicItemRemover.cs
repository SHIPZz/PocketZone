using Services.DependencyContainer;
using UI;
using UnityEngine;

public class DynamicItemRemover : MonoBehaviour
{
    private DynamicItemRemoverInput _dynamicItemRemoverInput;
    private InventoryPresenter _inventoryPresenter;
    
    private void Awake()
    {
        _inventoryPresenter = ServiceLocator.Get<InventoryPresenter>();
        _dynamicItemRemoverInput = GetComponent<DynamicItemRemoverInput>();
    }

    private void OnEnable()
    {
        _dynamicItemRemoverInput.Clicked += OnButtonClicked;
    }

    private void OnDisable()
    {
        _dynamicItemRemoverInput.Clicked -= OnButtonClicked;
    }

    private void OnButtonClicked(DynamicItem dynamicItem)
    {
       
    }
}
