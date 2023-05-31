using System;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class DynamicItemRemoverInput : MonoBehaviour
    {
        public event Action<DynamicItem> Clicked;
        
        private Button _button;
        
        private void Awake()
        {
            _button = GetComponent<Button>();
        }

        private void OnEnable()
        {
            _button.onClick.AddListener(OnButtonClicked);
        }

        private void OnDisable()
        {
            _button.onClick.RemoveListener(OnButtonClicked);
        }
        
        private void OnButtonClicked()
        {
            Clicked?.Invoke(GetComponent<DynamicItem>());
        }
    }
}