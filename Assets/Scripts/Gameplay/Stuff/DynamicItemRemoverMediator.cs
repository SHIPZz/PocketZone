﻿using System;
using Gameplay.Stuff;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class DynamicItemRemoverMediator : MonoBehaviour
    {
        [SerializeField] private Button _removeButton;
        
        private DynamicItemInput _dynamicItemInput;

        private DynamicItemRemover _dynamicItemRemover;
        private DynamicItem _dynamicItem;
        
        public InventoryPresenter InventoryPresenter { get; set; }

        private void Awake()
        {
            _dynamicItemInput = GetComponent<DynamicItemInput>();
        }
        
        private void Start()
        {
            _dynamicItemRemover = new(InventoryPresenter);
            _removeButton.gameObject.SetActive(false);
        }

        private void OnEnable()
        {
            _dynamicItemInput.Clicked += OnItemClicked;
            _removeButton.onClick.AddListener(OnRemoveButtonClicked);
        }
        
        private void OnDisable()
        {
            _removeButton.onClick.RemoveListener(OnRemoveButtonClicked);
            _dynamicItemInput.Clicked -= OnItemClicked;
        }
        
        private void OnRemoveButtonClicked()
        {
            _dynamicItemRemover.Remove(_dynamicItem);
        }

        private void OnItemClicked(DynamicItem dynamicItem)
        {
            _removeButton.gameObject.SetActive(true);
            _dynamicItem = dynamicItem;
        }
    }
}