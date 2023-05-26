using System;
using UnityEngine;
using UnityEngine.UI;

namespace Gameplay.Player
{
    public class PlayerInput : MonoBehaviour
    {
        [SerializeField] private Button _shootButton;
        
        public event Action MouseClicked;

        private void OnEnable()
        {
            _shootButton.onClick.AddListener(OnShootButtonClicked);
        }
        
        private void OnDisable()
        {
            _shootButton.onClick.RemoveListener(OnShootButtonClicked);
        }
        
        private void OnShootButtonClicked()
        {
            MouseClicked?.Invoke();
        }
    }
}
