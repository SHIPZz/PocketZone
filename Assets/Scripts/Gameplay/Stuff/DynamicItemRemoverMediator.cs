using System;
using Services.DependencyContainer;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class DynamicItemRemoverMediator : MonoBehaviour
    {
        [SerializeField] private Button _removeButton;
        
        private DynamicItemRemoverInput _dynamicItemRemoverInput;
        private InventoryPresenter _inventoryPresenter;
        private DynamicItem _dynamicItem;

        private void Awake()
        {
            _dynamicItemRemoverInput = GetComponent<DynamicItemRemoverInput>();
            _inventoryPresenter = ServiceLocator.Get<InventoryPresenter>();
            _removeButton.gameObject.SetActive(false);
        }

        private void OnEnable()
        {
            _dynamicItemRemoverInput.Clicked += OnItemClicked;
            _removeButton.onClick.AddListener(OnRemoveButtonClicked);
        }
        
        private void OnDisable()
        {
            _removeButton.onClick.RemoveListener(OnRemoveButtonClicked);
            _dynamicItemRemoverInput.Clicked -= OnItemClicked;
        }
        
        private void OnRemoveButtonClicked()
        {
            _inventoryPresenter.RemoveItemFromInventory(_dynamicItem);
        }

        private void OnItemClicked(DynamicItem dynamicItem)
        {
            _removeButton.gameObject.SetActive(true);
            _dynamicItem = dynamicItem;
        }
    }
}