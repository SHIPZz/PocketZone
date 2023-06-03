using System;
using Extensions.GameObjectExtension;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class DynamicItemInput : MonoBehaviour
    {
        public event Action<DynamicItem> Clicked;
        
        private Button _itemButton;
        
        private void Awake()
        {
            _itemButton = GetComponent<Button>();
        }

        private void OnEnable()
        {
            _itemButton.onClick.AddListener(OnItemClicked);
        }

        private void OnDisable()
        {
            _itemButton.onClick.RemoveListener(OnItemClicked);
        }
        
        private void OnItemClicked()
        {
            Clicked?.Invoke(GetComponent<DynamicItem>());
        }
    }
}