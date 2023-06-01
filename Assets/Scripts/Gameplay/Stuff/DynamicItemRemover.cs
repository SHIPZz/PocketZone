using Services.DependencyContainer;
using UI;
using UnityEngine;

public class DynamicItemRemover : MonoBehaviour
{
    private DynamicItemRemoverInput _dynamicItemRemoverInput;
    
    public InventoryPresenter InventoryPresenter { get; set; }
    
    private void Awake()
    {
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
